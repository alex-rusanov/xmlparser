namespace XmlParser.Core.Models
{
    public abstract class TextFile : BindableBase
    {
        private string _path;

        public string Path
        {
            get => _path;
            set
            {
                _path = value;
                OnPropertyChanged();
            }
        }

        protected string Content { get; }

        protected TextFile(string path, string content)
        {
            Path = path;
            Content = content;
        }
    }
}
