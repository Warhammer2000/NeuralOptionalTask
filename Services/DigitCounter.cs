using System;
using System.Collections.Generic;
using System.IO;

namespace OptionalTaskNeuralNetworks.Services
{
    internal class DigitCounter
    {
        private readonly string _directoryPath;
        private readonly int[] _digitCounts;

        public DigitCounter(string directoryPath)
        {
            _directoryPath = directoryPath;
            _digitCounts = new int[10]; 
        }

        public void CountDigits()
        {
            foreach (string file in Directory.EnumerateFiles(_directoryPath, "*", SearchOption.AllDirectories))
            {
                string content = File.ReadAllText(file);

                foreach (char c in content)
                {
                    if (char.IsDigit(c))
                    {
                        int digitIndex = c - '0'; 
                        if (digitIndex >= 0 && digitIndex < 10)
                        {
                            _digitCounts[digitIndex]++;
                        }
                    }
                }
            }
        }
        public int[] GetDigitCounts()
        {
            return _digitCounts;
        }

        public void PrintDigitCounts()
        {
            Console.WriteLine("Количество цифр от 0 до 9:");
            for (int i = 0; i < _digitCounts.Length; i++)
            {
                Console.WriteLine($"{i}: {_digitCounts[i]}");
            }
        }
    }
}
