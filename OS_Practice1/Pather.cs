using System;
using System.Text.RegularExpressions;

namespace OS_Practice1
{
    internal static class Pather
    {
        internal static string Enter(string message, bool flag)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input) || input.Trim() == string.Empty)
            {
                Console.Clear();
                Console.WriteLine($"{message}");
                input = Console.ReadLine();
            }
            
            return EnterCheck(input.Replace(" ", ""), flag);
        }

        /// <summary>
        /// Проверка файла или пути на содержание запрещенных символов
        /// </summary>
        /// <param name="input"></param>
        /// <param name="flag">
        /// Если True, то это путь, иначе это файл 
        /// </param>
        /// <returns></returns>
        private static string EnterCheck(string input, bool flag)
        {
            if ((!Regex.IsMatch(input, @"[""<>\?|*]") && flag) 
                || (!Regex.IsMatch(input, @"[""<>:\\?\/|*]") && !flag))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Кажется вы используете запрещенные символы");
                if (flag)
                {
                    input = Trim(input, true);
                    return input;
                }
                else
                {
                    input = Trim(input, false);
                    return input;
                }
            }
        }

        /// <summary>
        /// Удаление лишних символов
        /// </summary>
        /// <param name="path"></param>
        /// <param name="flag">
        /// Если True, то это путь, иначе это файл 
        /// </param>
        private static string Trim(string path, bool flag)
        {
            if (flag)
            {
                string[] charsToRemove = {" ", "\"", "<", ">", "?", "|", "*"};
                foreach (string c in charsToRemove)
                {
                    path = path.Replace(c, string.Empty);
                }
            }
            else
            {
                string[] charsToRemove = {" ", "\"", "<", ">", ":", "\\", "?", "/", "|", "*"};
                foreach (string c in charsToRemove)
                {
                    path = path.Replace(c, string.Empty);
                }
            }

            if (string.IsNullOrEmpty(path) || path.Trim() == string.Empty)
            {
                return Enter("Некорректные символы", flag);
            }

            Console.WriteLine($"Но ничего страшного, теперь путь выглядит так {path}");
            return path;
        }
    }
}