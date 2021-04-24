using FileManagementSystem.Logic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystem
{
    public class ConsoleMenu
    {
        private Listener _listener;
        private RollbackService _rollbackService;

        public void Start()
        {
            do
            {
                PrintMenu();
                var value = Console.ReadLine();
                if (!int.TryParse(value, out int option) || option <= 0 || option > Enum.GetValues(typeof(Actions)).Length)
                    break;

                var directory = EnterDirectory();

                try
                {
                    ExecuteAction((Actions)option, directory);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            } while (true);
        }

        private void ExecuteAction(Actions option, string directory)
        {
            switch (option)
            {
                case Actions.None:
                    break;
                case Actions.Listener:
                    _listener?.End();
                    _listener = new Listener(directory);
                    _listener.Start();
                    Console.WriteLine("Режим наблюдения работает, можете работать с директорией...");
                    break;
                case Actions.Rollback:
                    _listener?.End();
                    _rollbackService = new RollbackService(directory);
                    var dateTime = EnterDateTime();
                    _rollbackService.Rollback(dateTime);
                    Console.WriteLine("Откат произошел успешно!");
                    break;
            }
        }

        private string EnterDirectory()
        {
            do
            {
                Console.WriteLine("Введите директорию:");
                var directory = Console.ReadLine();
                if (Directory.Exists(directory))
                    return directory;
                else
                    Console.WriteLine("Данная директория не существует, введите еще раз:");

            } while (true);
        }

        private DateTime EnterDateTime()
        {
            do
            {
                Console.WriteLine("Введите дату и время отката в формате 'дд.ММ.гггг чч:мм:сс':");
                var dateTime = Console.ReadLine();
                if (DateTime.TryParseExact(dateTime, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                    return result;
                else
                    Console.WriteLine("Введенное время некорректное, введите еще раз:");

            } while (true);
        }

        private void PrintMenu()
        {
            Console.WriteLine(string.Join(Environment.NewLine,
                "Выберите действие или введите любой другой текст для выхода:",
                "1. Включить режим наблюдения",
                "2. Включить режим отката"));
        }
    }
}