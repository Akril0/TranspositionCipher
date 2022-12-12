using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranspositionCipher
{
     class PolyalphabeticSubstitution
    {
        private int[,]encrcryptTable= null;
        private string key = null;
        public PolyalphabeticSubstitution()
        {
            encrcryptTable = new int[256,256];
            for(int i = 0 ; i<256; i++)
            {
                for(int k =0; k<256; k++)
                {
                    encrcryptTable[i,k] = k+i;
                }
            }
        }
        public void SetKey (string _key)
        {
            key = _key;
        }

        public string Encrypt (string input)
        {
            string result = "";
            for (int i =0 ; i<input.Length;)
            {
                for(int k = 0; k<key.Length; k++)
                {
                    result += (char)encrcryptTable[(int)key[k], (int)input[i]];
                    i++;
                    if(i>=input.Length) break;
                }
            }
            return result;
        }

        public string Decrypt(string input)
        {
            string result = "";
            for (int i = 0, k = 0; i < input.Length; i++, k++)
            {
                if (k >= key.Length) k = 0;
                for (int j = 0; j < 256; j++)
                {
                    if ((int)input[i] == encrcryptTable[(int)key[k], j])
                    {
                        result += (char)j;
                        break;
                    }
                }
            }
            return result;
        }

    }
}