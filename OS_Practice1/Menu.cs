using System;

namespace OS_Practice1
{
    internal static class Menu
    {
        private static void PrintOptions()
        {
            Console.WriteLine("Выберете пункт:");
            Console.WriteLine("1.Информация о дисках");
            Console.WriteLine("2.Файлы");
            Console.WriteLine("3.JSON");
            Console.WriteLine("4.XML");
            Console.WriteLine("5.ZIP архив");
            Console.WriteLine("6.Выход");
        }

        internal static void Show()
        {
            while (true)
            {
                PrintOptions();
                string choice = Console.ReadLine();

                Console.WriteLine(choice);
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        Drives.ShowDrive();
                        break;
                    case "2":
                        Files.Write();
                        break;
                    case "3":
                        Json.Create();
                        break;
                    case "4":
                        Xml.Create();
                        break;
                    case "5":
                        Archive.Create();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неизвестное значение");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}