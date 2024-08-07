﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml;


namespace DomainLayer.Engine
{
    public class XML<T> : Database<T>
    {
        private const string Root = "IIS";
        private const string Row = "Row";
        private const string IncrementId = "IncrementId";
        
        private string _filePath;

        public XML(Model<T> model) : base(model) {}

        public void SetDataFilePath(string dataFilePath)
        {
            _filePath = dataFilePath;
        }
        
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

        private XmlDocument GetXmlDocument()
        {
            var xml = new XmlDocument();
            xml.LoadXml(System.IO.File.ReadAllText(_filePath));

            return xml;
        }

        private string GetIncrementId(XmlDocument xml, XmlNode node)
        {
            var incrementId = node.Attributes[IncrementId];
            if (incrementId == null)
            {
                incrementId = xml.CreateAttribute(IncrementId);
                incrementId.Value = "1";
                node.Attributes.SetNamedItem(incrementId);
            }

            var result = incrementId.Value;
            incrementId.Value = (int.Parse(result) + 1).ToString();
            
            return result;
        }
        
        private IEnumerable<T> ExecuteReader(string xpath)
        {
            var xml = GetXmlDocument();
            
            var result = new List<T>();

            foreach (XmlNode node in xml.SelectNodes(xpath))
            {
                var model = (T)Activator.CreateInstance(typeof(T), new XMLConnection(_filePath));
                
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
                if (PropertyIsNotMapped(property)) continue;
                
                var value = PropertyIsKey(property) ? GetIncrementId(xml, node) : 
                    property.GetValue(Model, null)?.ToString();
                
                if (string.IsNullOrWhiteSpace(value) && PropertyIsRequired(property))
                {
                    throw new Exception("Required attribute is missing!");
                }

                if (!string.IsNullOrWhiteSpace(value) && property.PropertyType == typeof(DateTime?))
                {
                    value = FormatDateTimeString(value);
                }

                var valueNode = xml.CreateNode(XmlNodeType.Element, property.Name, "");

                valueNode.InnerText = value;

                rowNode.AppendChild(valueNode);
            }

            node.AppendChild(rowNode);
            
            xml.Save(_filePath);
        }
        
        private void ExecuteUpdate(string xpath)
        {
            var xml = GetXmlDocument();
            
            var node = xml.SelectSingleNode(xpath);

            foreach (var property in typeof(T).GetProperties())
            {
                var value = property.GetValue(Model, null)?.ToString();

                if (string.IsNullOrWhiteSpace(value)) continue;

                var valueNode = node.SelectSingleNode(property.Name);

                if (valueNode == null) continue;
                
                if (property.PropertyType == typeof(DateTime?))
                {
                    value = FormatDateTimeString(value);
                }

                valueNode.InnerText = value;
            }

            xml.Save(_filePath);
        }
        
        private void ExecuteDelete(string xpath)
        {
            var xml = GetXmlDocument();
            
            var node = xml.SelectSingleNode(xpath);
            
            node.ParentNode.RemoveChild(node);
            
            xml.Save(_filePath);
        }
    }
}