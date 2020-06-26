using System.Xml.Linq;

namespace XmlParser.Core.Models
{
    public class XmlFile : TextFile
    {
        private string _formattedXml;
        private readonly XDocument _xmlDocument;

        public XmlFile(string path, string content) : base(path, content)
        {
            _xmlDocument = XDocument.Parse(content);
        }

        public string FormattedXml => _formattedXml ??= _xmlDocument.ToString();
    }
}
