using System.Windows;
using System.Windows.Input;
using XmlParser.Core.Models;
using XmlParser.Core.Tools;

namespace XmlParser.Core.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region Fields

        private ICommand _exitCommand;
        private ICommand _openFileCommand;
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

        public ICommand OpenFileCommand => _openFileCommand ??= new RelayCommand<object>(_ =>
        {
            if (FileManager.OpenXml(out _xmlFile))
            {
                XmlFile = _xmlFile;
            }
        });

        public ICommand ExitCommand => _exitCommand ??= new RelayCommand<Window>(window => window.Close());

        #endregion
    }
}
