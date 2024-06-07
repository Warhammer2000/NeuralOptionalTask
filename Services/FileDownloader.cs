using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OptionalTaskNeuralNetworks.Services
{
    internal class FileDownloader
    {
        public string DownloadFileFromUrl(string url, string downloadPath)
        {
            try
            {
                string tempFilePath = Path.Combine(downloadPath, "downloaded_digits.zip");

                if (!Directory.Exists(downloadPath))
                {
                    Directory.CreateDirectory(downloadPath);
                }

                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(url, tempFilePath);
                }

                if (File.Exists(tempFilePath))
                {
                    Console.WriteLine($"Файл успешно загружен в {tempFilePath}");
                    return tempFilePath;
                }
                else
                {
                    Console.WriteLine($"Файл не был загружен в {tempFilePath}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке файла: {ex.Message}");
                return null;
            }
        }
    }
}
