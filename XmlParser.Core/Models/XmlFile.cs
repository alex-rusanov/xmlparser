using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace XmlParser.Core.Models
{
    public class XmlFile : TextFile
    {
        #region Fields

        private string _content;
        private readonly XDocument _xDocument;

        #endregion

        #region Props

        public new string Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Ctor

        public XmlFile(string path, string content) : base(path, content)
        {
            _xDocument = XDocument.Parse(content);
            _content = _xDocument.ToString();
        }

        #endregion

        #region Public Methods

        public void Evaluate(string xpath)
        {
            if (string.IsNullOrWhiteSpace(xpath))
            {
                return;
            }

            try
            {
                var evaluation = _xDocument.XPathEvaluate(xpath);

                if (evaluation is IEnumerable<object> enumerable)
                {
                    Content = string.Join('\n', enumerable.Select(obj => obj.ToString()));
                }
                else
                {
                    Content = evaluation.ToString();
                }
            }
            catch (XPathException exception)
            {
                Content = exception.Message;
            }
        }

        #endregion
    }
}
