using DomainLayer.Engine;

namespace DomainLayer.Engine
{
    public class XMLConnection : Connection
    {
        private string XmlDataFilePath { get; set; }

        public XMLConnection(string xmlDataFilePath)
        {
            XmlDataFilePath = xmlDataFilePath;
        }

        public override Database<T> Create<T>(Model<T> model)
        {
            var database = new XML<T>(model);
            database.SetDataFilePath(XmlDataFilePath);
            return database;
        }
    }
}