using System;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace ClientZP
{

    public partial class App : Application { }

    /// <summary>
    /// Класс предназначенный для логирования
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Метод создания лога
        /// </summary>
        /// <param name="message">Лог-сообщение</param>
        public static void Log(string message)
        {
            if (!Directory.Exists("Logs"))
            {

                Directory.CreateDirectory("Logs");
            }
            using (StreamWriter writer = new StreamWriter("Logs/log.txt"))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }
    }
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}