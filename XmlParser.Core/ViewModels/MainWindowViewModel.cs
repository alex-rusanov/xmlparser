using System.Windows;
using System.Windows.Input;
using System.Xml;
using XmlParser.Core.Models;
using XmlParser.Core.Tools;

namespace XmlParser.Core.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region Fields

        private ICommand _applyXpathCommand;
        private ICommand _exitCommand;
        private ICommand _openFileCommand;
        private string _status = "Open File to Proceed";
        private string _xPath;
        private XmlFile _xmlFile;

        #endregion

        #region Props

        public XmlFile XmlFile
        {
            get => _xmlFile;
            set
            {
                _xmlFile = value;
                OnPropertyChanged();
            }
        }

        public string XPath
        {
            get => _xPath;
            set
            {
                _xPath = value;
                OnPropertyChanged();
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        public ICommand OpenFileCommand => _openFileCommand ??= new RelayCommand<object>(_ =>
        {
            try
            {
                if (FileManager.OpenXml(out _xmlFile))
                {
                    XmlFile = _xmlFile;
                    Status = XmlFile.Path;
                }
                else
                {
                    XmlFile = null;
                }
            }
            catch (XmlException exception)
            {
                XmlFile = null;
                Status = exception.Message;
            }

            XPath = string.Empty;
        });

        public ICommand ExitCommand => _exitCommand ??= new RelayCommand<Window>(window => window.Close());

        public ICommand ApplyXpathCommand => _applyXpathCommand ??= new RelayCommand<object>(_ => XmlFile.Evaluate(XPath));

        #endregion
    }
}
