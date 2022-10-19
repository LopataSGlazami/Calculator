using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ViewModels
{
    public class Command : ICommand
    {
        private readonly Action action;

        public Command(Action action, Func<bool>? canExecute = null)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        private readonly Func<bool>? canExecute;

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? _)
        {
            return canExecute == null ? true : canExecute();
        }

        public void Execute(object? _)
        {
            if (CanExecute(null)) action.Invoke();
            RaiseCanExecuteChanged();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
            
    }

    public class Command<T> : ICommand
    {
        private readonly Action<T> action;

        public Command(Action<T> action, Func<T, bool>? canExecute = null)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        private readonly Func<T, bool>? canExecute;

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? param)
        {
            return canExecute == null || canExecute((T)param);
        }

        public void Execute(object? param)
        {
            action.Invoke((T)param);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

    }
}
