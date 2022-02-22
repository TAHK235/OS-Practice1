using System;
using System.IO;

namespace OS_Practice1
{
    internal static class Files
    {
        internal static void Write()
        {
            bool directoryNotExists = false;
            bool flag = Menu.Ask();
            Console.Clear();

            string message = flag ? @"Введите полный путь файла путь файла, например c:\temp.txt" : "Введите название файла";

            string path = Pather.Enter(message, flag);
            FileInfo file = new FileInfo(path);
            if (!Directory.Exists(Convert.ToString(Directory.GetParent(path))))
            {
                directoryNotExists = true;
                Console.WriteLine("Такого пути не было, но теперь есть!");
                Directory.CreateDirectory(Convert.ToString(Directory.GetParent(path)));
            }

            Console.WriteLine($"Место расположения файла {Path.GetFullPath(path)}");

            Console.WriteLine("Введите строку для записи в файл:");
            string text = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine(text);
            }

            using (StreamReader sr = new StreamReader(path, false))
            {
                Console.WriteLine("\nТекст в файле:");
                Console.WriteLine(sr.ReadToEnd());
            }

            Menu.Delete(file);
            if (directoryNotExists)
            {
                Directory.Delete(Convert.ToString(Directory.GetParent(path)));
                Console.WriteLine("Созданный путь для файла был удалён!");
            }
        }
    }
}