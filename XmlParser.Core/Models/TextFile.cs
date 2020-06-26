using XmlParser.Core.Tools;

namespace XmlParser.Core.Models
{
    public abstract class TextFile : BindableBase
    {
        #region Fields

        private string _path;

        #endregion

        #region Props

        protected string Content { get; }

        public string Path
        {
            get => _path;
            set
            {
                _path = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Ctor

        protected TextFile(string path, string content)
        {
            Path = path;
            Content = content;
        }

        #endregion
    }
}
