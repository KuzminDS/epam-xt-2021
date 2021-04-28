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
        public void Start()
        {
            do
            {
                PrintMenu();

                if (!TryEnterMenuAction(out MenuActions option))
                    break;

                var directory = EnterDirectory();

                try
                {
                    ExecuteAction(option, directory);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            } while (true);
        }

        private void PrintMenu()
        {
            Console.WriteLine(string.Join(Environment.NewLine,
                "Выберите действие или введите любой другой текст для выхода:",
                "1. Включить режим наблюдения",
                "2. Включить режим отката"));
        }

        private bool TryEnterMenuAction(out MenuActions option)
        {
            var value = Console.ReadLine();
            return Enum.TryParse(value, out option) && option > 0 && Enum.IsDefined(typeof(MenuActions), option);
        }

        private void ExecuteAction(MenuActions option, string directory)
        {
            switch (option)
            {
                case MenuActions.None:
                    break;
                case MenuActions.Listener:
                    using (var listener = new Listener(directory))
                    {
                        listener.Start();
                        Console.WriteLine("Режим наблюдения работает, можете работать с директорией. Для завершения работы нажмите любую клавишу.");
                        Console.ReadKey();
                    }
                    break;
                case MenuActions.Rollback:
                    var rollbackService = new RollbackService(directory);
                    var dateTime = EnterDateTime();
                    rollbackService.Rollback(dateTime);
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
    }
}