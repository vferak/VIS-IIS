using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml;


namespace IIS.Engine
{
    public class XML<T> : Database<T>
    {
        private const string FilePath = "D:\\Users\\vfera\\Documents\\000 Vojta\\VSB\\5_Semestr\\VIS\\IIS\\IIS\\IIS\\Data.xml";
        private const string Root = "IIS";
        private const string Row = "Row";

        public XML(Model<T> model) : base(model) {}
        
        public override T LoadOne()
        {
            return Load().FirstOrDefault();
        }

        public override IEnumerable<T> Load()
        {
            return LoadXPath(BuildXPathStringWithParameters());
        }

        public IEnumerable<T> LoadXPath(string xpath)
        {
            return ExecuteReader(xpath);
        }

        public override void Save()
        {
            if (IsInsert())
            {
                //todo generovat key ID
                ExecuteInsert(BuildXPathString(false));
            }
            else
            {
                ExecuteUpdate(BuildXPathStringWithParameters(true));
            }
        }

        public override void Delete()
        {
            if (LoadOne() != null)
            {
                ExecuteDelete(BuildXPathStringWithParameters());
            }
        }
        
        private static string BuildXPathString(bool withRow = true)
        {
            return $"/{Root}/{typeof(T).Name}" + (withRow ? $"/{Row}" : "");
        }
        
        private string BuildXPathStringWithParameters(bool onlyKey = false)
        {
            var xpath = BuildXPathString();
            
            var where = new List<string>();
            
            foreach (var property in typeof(T).GetProperties())
            {
                var value = property.GetValue(Model, null)?.ToString();
                
                if (value == null || PropertyIsNotMapped(property) || onlyKey && !PropertyIsKey(property)) continue;

                if (property.PropertyType == typeof(DateTime?))
                {
                    value = FormatDateTimeString(value);
                }
                
                where.Add(property.Name + " = \"" + value + "\"");
            }
            
            var whereString = string.Join(" and ", where.ToArray());

            if (!string.IsNullOrWhiteSpace(whereString))
            {
                whereString = $"[{whereString}]";
            }

            return xpath + whereString;
        }

        private static XmlDocument GetXmlDocument()
        {
            var xml = new XmlDocument();
            xml.LoadXml(System.IO.File.ReadAllText(FilePath));

            return xml;
        }
        
        private IEnumerable<T> ExecuteReader(string xpath)
        {
            var xml = GetXmlDocument();
            
            var result = new List<T>();

            foreach (XmlNode node in xml.SelectNodes(xpath))
            {
                var model = (T)Activator.CreateInstance(typeof(T), new XMLConnection());
                
                foreach (var property in typeof(T).GetProperties())
                {
                    var valueNode = node.SelectSingleNode(property.Name);
                    
                    if (valueNode == null) continue;
                    
                    var value = string.IsNullOrWhiteSpace(valueNode.InnerText) ? null : valueNode.InnerText;
                    var converter = TypeDescriptor.GetConverter(property.PropertyType);
                    property.SetValue(model, converter.ConvertFromString(value));
                }
                
                result.Add(model);
            }

            return result;
        }

        private void ExecuteInsert(string xpath)
        {
            var xml = GetXmlDocument();
                
            var node = xml.SelectSingleNode(xpath);
            
            var rowNode = xml.CreateNode(XmlNodeType.Element, Row, "");
            
            foreach (var property in typeof(T).GetProperties())
            {
                var value = property.GetValue(Model, null)?.ToString();

                if (string.IsNullOrWhiteSpace(value) && (PropertyIsKey(property) || PropertyIsRequired(property)))
                {
                    throw new Exception("Required attribute is missing!");
                }

                if (!string.IsNullOrWhiteSpace(value) && property.PropertyType == typeof(DateTime?))
                {
                    value = FormatDateTimeString(value);
                }
                
                if (PropertyIsNotMapped(property)) continue;

                var valueNode = xml.CreateNode(XmlNodeType.Element, property.Name, "");

                valueNode.InnerText = value;

                rowNode.AppendChild(valueNode);
            }

            node.AppendChild(rowNode);
            
            xml.Save(FilePath);
        }
        
        private void ExecuteUpdate(string xpath)
        {
            var xml = GetXmlDocument();
            
            var node = xml.SelectSingleNode(xpath);

            foreach (var property in typeof(T).GetProperties())
            {
                var value = property.GetValue(Model, null)?.ToString();

                if (string.IsNullOrWhiteSpace(value))
                {
                    if (PropertyIsKey(property) || PropertyIsRequired(property))
                    {
                        throw new Exception("Required attribute is missing!");
                    }

                    continue;
                }

                if (property.PropertyType == typeof(DateTime?))
                {
                    value = FormatDateTimeString(value);
                }

                var valueNode = node.SelectSingleNode(property.Name);

                if (valueNode == null) continue;

                valueNode.InnerText = value;
            }

            xml.Save(FilePath);
        }
        
        private void ExecuteDelete(string xpath)
        {
            var xml = GetXmlDocument();
            
            var node = xml.SelectSingleNode(xpath);
            
            node.ParentNode.RemoveChild(node);
            
            xml.Save(FilePath);
        }
    }
}