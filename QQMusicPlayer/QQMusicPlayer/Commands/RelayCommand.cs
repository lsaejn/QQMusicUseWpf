using System;
using System.Windows.Input;

namespace QQMusicPlayer.Commands
{
    public class RelayCommand : ICommand
    {

        readonly Func<Boolean> canExecute_;
        readonly Action<object> execute_;



        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }
        public RelayCommand(Action<object> execute, Func<Boolean> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            execute_ = execute;
            canExecute_ = canExecute;
        }



        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (canExecute_ != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (canExecute_ != null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        //[DebuggerStepThrough]
        public Boolean CanExecute(Object parameter)
        {
            return canExecute_ == null ? true : canExecute_();
        }

        public void Execute(Object parameter)
        {
            execute_(parameter);
        }

    }
}
