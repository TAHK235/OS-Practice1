using System;
using System.IO;
using System.Xml.Linq;

namespace OS_Practice1
{
    internal static class Xml
    {
        internal static void Create()
        {
            string path = @"C:\temp.xml";
            FileInfo file = new FileInfo(path);

            Console.WriteLine("Введите имя:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите возраст:");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите компанию:");
            string company = Console.ReadLine();

            XDocument xdoc = new XDocument();
            XElement user1 = new XElement("user1");
            XAttribute userAttribute = new XAttribute("name", name);
            XElement ageElement = new XElement("age", $"{age}");
            XElement compElement = new XElement("company", company);
            user1.Add(userAttribute);
            user1.Add(ageElement);
            user1.Add(compElement);
            XElement users = new XElement("users");
            users.Add(user1);
            xdoc.Add(users);
            xdoc.Save(path);

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
