using System;
using System.Windows.Input;

namespace XmlParser.Core.Tools
{
    public class RelayCommand<T> : ICommand
    {
        #region Fields

        private readonly Action<T> _action;
        private readonly Predicate<T> _canExecute;

        #endregion

        #region Events

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        #endregion

        #region Ctor

        public RelayCommand(Action<T> action, Predicate<T> canExecute = null)
        {
            _action = action;
            _canExecute = canExecute;
        }

        #endregion

        #region Public Methods

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute((T)parameter);

        public void Execute(object parameter) => _action((T)parameter);

        #endregion
    }
}