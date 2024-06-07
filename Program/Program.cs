using System;
using System.IO;
using OptionalTaskNeuralNetworks.Services;
using OptionalTaskNeuralNetworks.Utilities;

namespace OptionalTaskNeuralNetworks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InitialCreate();
        }

        private static void InitialCreate()
        {
            string localZipPath = @"C:\Itransition_Internship\OptionalTaskNeuralNetworks\Archives\digits.zip";
            string downloadPath = @"C:\Itransition_Internship\OptionalTaskNeuralNetworks\Archives";
            string extractPath = @"C:\Itransition_Internship\OptionalTaskNeuralNetworks\ExtractedFiles";
            string downloadUrl = "https://www.dropbox.com/s/y9bs6r4nc7pj48c/digits.zip?dl=1";

            DirectoryCleaner.ClearDirectory(extractPath);
            string zipPath = GetZipPath(localZipPath, downloadPath, downloadUrl);

            if (string.IsNullOrEmpty(zipPath)) return;

            try
            {
                new ArchiveProcessor(zipPath, extractPath).ExtractFiles();
                DigitCounter digitCounter = new DigitCounter(extractPath);
                digitCounter.CountDigits();

                digitCounter.PrintDigitCounts();
                Console.WriteLine("Массив: [" + string.Join(", ", digitCounter.GetDigitCounts()) + "]");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
            finally
            {
                DirectoryCleaner.ClearDirectory(extractPath);
                Console.WriteLine("Для завершения работы нажмите любую клавишу.");
                Console.ReadKey();
            }
        }
        private static string GetZipPath(string localZipPath, string downloadPath, string downloadUrl)
        {
            Console.WriteLine("Выберите метод:\n1: Использовать локальный файл\n2: Загрузить файл по URL");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                if (File.Exists(localZipPath)) return localZipPath;
                Console.WriteLine($"Файл 'digits.zip' не найден по пути {localZipPath}");
            }
            else if (choice == "2")
            {
                string zipPath = new FileDownloader().DownloadFileFromUrl(downloadUrl, downloadPath);
                if (!string.IsNullOrEmpty(zipPath)) return zipPath;
                Console.WriteLine("Не удалось загрузить файл по URL.");
            }
            else
            {
                Console.WriteLine("Неверный выбор. Программа завершена.");
            }
            return null;
        }
    }
}
