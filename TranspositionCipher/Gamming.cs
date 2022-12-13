using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TranspositionCipher
{
    internal class Gamming
    {
        private int key;
        private const int RAND_MAX = 123241413;

        private uint GamminAlgoritm(int x)
        {
            uint next = (uint)key * 1103515245 + 12345;
            return ((uint)(next / 65536) % (uint)(RAND_MAX + x));
        }

        public void SetKey(string _key)
        {
            key= Int32.Parse( _key);
        }


        public string Encrypt(string text)
        {
            char[] array = text.ToCharArray();
            uint code;
            for (int x = 0; x < text.Length; x++)
            {
                code = (uint)array[x] + GamminAlgoritm(x);
      
                array[x] = (char)code;
            }
            string newText = new string(array);
            FileWrittng.WriteFile("Гаммирование", "Шифрование", key.ToString(), text, newText);
            return newText;
        }

        public string Decrypt(string text)
        {
            char[] array = text.ToCharArray();
            uint code;
            for (int x = 0; x < text.Length; x++)
            {
                code = (uint)array[x] - GamminAlgoritm(x);
     
                array[x] = (char)code;
            }
            string newText = new string(array);
            FileWrittng.WriteFile("Гаммирование", "Дешифрование", key.ToString(), text, newText);
            return newText;
        }
    }
}
