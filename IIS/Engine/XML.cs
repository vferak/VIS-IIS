using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;

namespace IIS.Engine
{
    public class XML<T> : Database<T>
    {
        private const string FilePath = "D:\\Users\\vfera\\Documents\\000 Vojta\\VSB\\5_Semestr\\VIS\\IIS\\IIS\\IIS\\Data.xml";
        private const string Root = "IIS";
        private const string Row = "Row";

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

        private IEnumerable<T> ExecuteReader(string xpath)
        {
            var result = new List<T>();

            try
            {
                var xml = new XmlDocument();
                xml.LoadXml(System.IO.File.ReadAllText(FilePath));


                foreach (XmlNode node in xml.SelectNodes(xpath))
                {
                    var model = (T)Activator.CreateInstance(typeof(T), this);
                    foreach (var property in typeof(T).GetProperties())
                    {
                        var valueNode = node.SelectSingleNode(property.Name);
                        
                        if (valueNode == null) continue;
                        
                        var value = valueNode.InnerText;
                        var converter = TypeDescriptor.GetConverter(property.PropertyType);
                        property.SetValue(model, converter.ConvertFromString(string.IsNullOrWhiteSpace(value) ? null : value));
                    }
                    result.Add(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        private void ExecuteInsert(string xpath)
        {
            try
            {
                var xml = new XmlDocument();
                xml.LoadXml(System.IO.File.ReadAllText(FilePath));
                
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
                        value = DateTime.Parse(value).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    
                    if (property.Name == "Connection") continue;

                    var valueNode = xml.CreateNode(XmlNodeType.Element, property.Name, "");

                    valueNode.InnerText = value;

                    rowNode.AppendChild(valueNode);
                }

                node.AppendChild(rowNode);
                
                xml.Save(FilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        private void ExecuteUpdate(string xpath)
        {
            try
            {
                var xml = new XmlDocument();
                xml.LoadXml(System.IO.File.ReadAllText(FilePath));
                
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
                        value = DateTime.Parse(value).ToString("yyyy-MM-dd HH:mm:ss");
                    }

                    var valueNode = node.SelectSingleNode(property.Name);

                    if (valueNode == null) continue;

                    valueNode.InnerText = value;
                }

                xml.Save(FilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        private void ExecuteDelete(string xpath)
        {
            try
            {
                var xml = new XmlDocument();
                xml.LoadXml(System.IO.File.ReadAllText(FilePath));
                
                var node = xml.SelectSingleNode(xpath);
                node.ParentNode.RemoveChild(node);
                xml.Save(FilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private string BuildXPathString(bool withRow = true)
        {
            return $"/{Root}/{typeof(T).Name}" + (withRow ? $"/{Row}" : "");
        }
        
        private string BuildXPathStringWithParameters(bool onlyKey = false)
        {
            var xpath = BuildXPathString();
            
            string whereString = null;
            foreach (var property in typeof(T).GetProperties())
            {
                var value = property.GetValue(Model, null);
                if (value == null || property.Name == "Connection" || onlyKey && !PropertyIsKey(property)) continue;

                if (property.PropertyType == typeof(DateTime?))
                {
                    value = DateTime.Parse(value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                }
                
                whereString = whereString == null ? "[" : whereString + " and ";
                whereString += property.Name + " = \"" + value + "\"";
            }

            if (whereString != null)
            {
                whereString += "]";
            }

            return xpath + whereString;
        }
    }
}