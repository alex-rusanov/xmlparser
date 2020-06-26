using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XmlParser.Core.Tools
{
    public abstract class BindableBase : INotifyPropertyChanged
    {
        #region Props

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Protected Methods

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
