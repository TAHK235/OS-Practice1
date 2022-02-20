using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Task3
{
    internal sealed class Person
    {
        [JsonPropertyName("Firstname")]
        public string Name { get; set; }

        public int Age { get; set; }
    }

    internal static class Program
    {
        private static void Main()
        {
            string path = @"C:\temp.json";
            FileInfo file = new FileInfo(path);

            Console.WriteLine("Введите имя:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите возраст:");
            int age = Convert.ToInt32(Console.ReadLine());
            Person person = new Person() { Name = name, Age = age };
            string json = JsonSerializer.Serialize(person);

            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine(json);
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