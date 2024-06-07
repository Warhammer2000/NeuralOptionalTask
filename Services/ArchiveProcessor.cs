using System;
using System.IO;
using System.IO.Compression;


namespace OptionalTaskNeuralNetworks.Services
{
    internal class ArchiveProcessor
    {
        private readonly string _archivePath;
        private readonly string _extractPath;

        public ArchiveProcessor(string archivePath, string extractPath)
        {
            _archivePath = archivePath;
            _extractPath = extractPath;
        }

        public void ExtractFiles()
        {
            try
            {
                if (!Directory.Exists(_extractPath))
                {
                    Directory.CreateDirectory(_extractPath);
                }

                if (File.Exists(_archivePath))
                {
                    Console.WriteLine($"Начинается извлечение архива {_archivePath} в {_extractPath}");
                    ZipFile.ExtractToDirectory(_archivePath, _extractPath);
                    Console.WriteLine("Извлечение успешно завершено.");
                }
                else
                {
                    Console.WriteLine($"Архив не найден: {_archivePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при извлечении файлов: {ex.Message}");
            }
        }

        public string GetExtractPath()
        {
            return _extractPath;
        }
    }
}
