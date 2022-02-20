using System;
using System.IO;

namespace Task2
{
    internal static class Program
    {
        private static void Main()
        {
            string path = @"C:\temp.txt";
            FileInfo file = new FileInfo(path);

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

            file.Delete();
            Console.WriteLine("Файл удален");
        }
    }
}