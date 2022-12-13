using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TranspositionCipher
{
    internal class Permutation
    {
        public string key;
        public string text;

        public void SetKey(string _key)
        {
            key = _key;
        }
        public int[] ToIntArray(string num)
        {
            int[] columns = new int[num.Length];
            for (int x = 0; x < columns.Length; x++)
            {
                columns[x] = (int)num[x] - (int)'0';
            }
            return columns;
        }


        public int[] SortIndexes(int[] columns, int[] sortCol)
        {
            int[] indexes = new int[columns.Length];
            for (int i = 0; i < indexes.Length; i++)
            {
                for (int j = 0; j < indexes.Length; j++)
                {
                    if (sortCol[i] == columns[j])
                    {
                        indexes[i] = j;
                        break;
                    }
                }
            }
            return indexes;
        }

        public string Partition(int[] indexes)
        {
            char[] array = text.ToCharArray();
            char[] newArray = new char[array.Length];
            int div, code, inArr;
            if (array.Length % indexes.Length != 0)
            {
                div = (array.Length / indexes.Length) + 1;
            }
            else
            {
                div = array.Length / indexes.Length;
            }
            for (int i = 0; i < indexes.Length; i++)
            {
                inArr = indexes[i];
                code = i;
                for (int j = 0; j < div; j++)
                {
                    newArray[code] = array[inArr];
                    inArr += div;
                    if (inArr >= array.Length) {
                        break;
                    }
                    code += div;
                    if (code >= array.Length)
                    {
                        code = array.Length - 1;
                    }
                }
            }
            return new string(newArray);
        }

        public string Encrypt(string input)
        {
            text = input;
            int[] columns = ToIntArray(key);
            int[] sortCol = ToIntArray(key);
            Array.Sort(sortCol);
            int[] indexes = SortIndexes(columns, sortCol);
            string newText = Partition(indexes);
            FileWrittng.WriteFile("вертикальної перестановки", "Шифрування", key, text, newText);
            return newText;
        }

        public string Decrypt(string input)
        {
            text = input;
            int[] columns = ToIntArray(key);
            int[] sortCol = ToIntArray(key);
                    Array.Sort(sortCol);
            int[] indexes = SortIndexes(sortCol, columns);
            string newText = Partition(indexes);
            FileWrittng.WriteFile("вертикальної перестановки", "Дешифрування", key, text, newText);
            return newText;
        }
    }
}
