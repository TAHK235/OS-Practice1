using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace OS_Practice1
{
    internal static class Archive
    {
        internal static void Create()
        {
            string sourceFolder = @"C:\Archive";
            string zipFile = @"C:\Archive.zip";
            DirectoryInfo di = Directory.CreateDirectory(sourceFolder);
            ZipFile.CreateFromDirectory(sourceFolder, zipFile);
            di.Delete();

            Console.WriteLine($"Папка {sourceFolder} архивирована в файл {zipFile}");
            Console.WriteLine("Введите путь файла для сжатия без кавычек:");
            string source = Console.ReadLine();

            using (FileStream zipToOpen = new FileStream(zipFile, FileMode.Open))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    string fileName = Path.GetFileName(source);
                    StreamReader sr = new StreamReader(source, Encoding.Default);
                    ZipArchiveEntry file = archive.CreateEntry(fileName);
                    using (StreamWriter writer = new StreamWriter(file.Open()))
                    {
                        writer.Write(sr.ReadToEnd());
                    }

                    sr.Close();
                }
            }

            string targetFolder = @"C:\Unzip";
            DirectoryInfo folder = Directory.CreateDirectory(targetFolder);
            ZipFile.ExtractToDirectory(zipFile, targetFolder);
            Console.WriteLine($"Файл {zipFile} распакован в папку {targetFolder}");

            folder.Delete(true);
            File.Delete(zipFile);
            Console.ReadLine();
        }
    }
}
