using System;
using System.IO;

namespace OptionalTaskNeuralNetworks.Utilities
{
    public static class DirectoryCleaner
    {
        public static void ClearDirectory(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    foreach (string file in Directory.GetFiles(path))
                    {
                        File.Delete(file);
                    }

                    foreach (string directory in Directory.GetDirectories(path))
                    {
                        Directory.Delete(directory, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при очистке папки '{path}': {ex.Message}");
            }
        }
    }
}
