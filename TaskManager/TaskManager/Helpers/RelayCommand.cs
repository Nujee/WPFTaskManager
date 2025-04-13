﻿using System;
using System.Windows.Input;

namespace TaskManager.Helpers
{
    public sealed class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke() ?? true;

        public void Execute(object parameter)
        {
            Console.WriteLine("Executing AddTask...");
            _execute();
        }

        public event EventHandler CanExecuteChanged;
    }
}
