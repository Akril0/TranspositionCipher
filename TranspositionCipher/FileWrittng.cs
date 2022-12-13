using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranspositionCipher
{
    internal class FileWrittng
    {
        public static void WriteFile(string cipher, string action, string key, string input, string output)
        {
            string path = @"./Cipher";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Шифр: " + cipher);
                    sw.WriteLine(action);
                    sw.WriteLine("Ключ: " + key);
                    sw.WriteLine("Введённый текст: " + input);
                    sw.WriteLine("Выведнный текст: " + output);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("Шифр: " + cipher);
                    sw.WriteLine(action);
                    sw.WriteLine("Ключ: " + key);
                    sw.WriteLine("Введённый текст: " + input);
                    sw.WriteLine("Выведнный текст: " + output);
                }
            }
        }
    }
}
