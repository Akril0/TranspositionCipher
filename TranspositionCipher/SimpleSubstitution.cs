using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranspositionCipher
{
    class SimpleSubstitution
    {
        private int key;

 

        public void SetKey(string _key)
        {
            key = Int32.Parse(_key);
            while (key>=256) {
                key-= 256;
            }
     
        }



        public string Encrypt(string input)
        {
            

            string result = "";

            for (int i = 0; i < input.Length; i ++)
            {
                int unicode = (int)(input[i]) + key;
                if (unicode >= 256) unicode -= 256;
                result += (char)unicode;
            }

            return result;
        }

        public string Decrypt(string input)
        {
            string result = "";

            for (int i = 0; i < input.Length; i++)
            {
                int unicode = (int)(input[i]) - key;
                if (unicode <0) unicode += 256;
                result += (char)unicode;
            }

            return result;
        }
    }
}