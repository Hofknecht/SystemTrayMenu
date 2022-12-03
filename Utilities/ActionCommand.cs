// <copyright file="ActionCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//
// Copyright (c) 2022-2022 Peter Kirmeier

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.Windows.Input;

    internal class ActionCommand : ICommand
    {
        private readonly Action<object> action;

        public ActionCommand(Action<object> action)
        {
            this.action = action;
        }

#pragma warning disable CS0067
        public event EventHandler? CanExecuteChanged;
#pragma warning restore CS0067

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter) => action.Invoke(parameter!);
    }
}
