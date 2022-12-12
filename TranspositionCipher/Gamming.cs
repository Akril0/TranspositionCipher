using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranspositionCipher
{
    internal class Gamming
    {
        public string key;

        public void SetKey(string _key)
        {
            key= _key;
        }


        public string Encrypt(string text)
        {
            char[] array = text.ToCharArray();
            char[] intKey = key.ToCharArray();
            int code;
            for (int x = 0; x < array.Length; x++)
            {
                code = (int)array[x] + (int)intKey[x];
                if (code >= 128)
                {
                    code -= 128;
                }
                array[x] = (char)code;
            }
            string newText = new string(array);
            return newText;
        }

        public string Decrypt(string text)
        {
            char[] array = text.ToCharArray();
            char[] intKey = key.ToCharArray();
            int code;
            for (int x = 0; x < text.Length; x++)
            {
                code = (int)array[x] - (int)intKey[x];
                if (code <=32 )
                {
                    code = 128 + code;
                }
                array[x] = (char)code;
            }
            string newText = new string(array);
            return newText;
        }
    }
}
