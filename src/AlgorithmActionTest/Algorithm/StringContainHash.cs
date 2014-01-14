using System;

namespace AlgorithmAction.Algorithm
{
    public class StringContainHash
    {
        private int[] _hash = new int[26];

        public void CompareString(string longStr, string shortStr)
        {
            char[] longChars = longStr.ToUpper().ToCharArray();
            char[] shortChars = shortStr.ToUpper().ToCharArray();
            GenerateHash(longChars, shortChars);
        }

        public int GenerateHash(char[] longStr, char[] shortStr)
        {
            int num = 0;
            for (int j = 0, len = shortStr.Length; j < len; j++)
            {
                int index = shortStr[j] - 'A';
                if (_hash[index] == 0)
                {
                    _hash[index] = 1;
                    num++;
                }
            }

            for (int k = 0, len = longStr.Length; k < len; k++)
            {
                int index = longStr[k] - 'A';

                if (_hash[index] == 1)
                {
                    _hash[index] = 0;
                    num--;
                    if (num == 0)
                        break;
                }
            }

            if (num == 0)
            {
                Console.WriteLine("true");
                return 0;
            }
            else
            {
                Console.WriteLine("false");
                return -1;
            }

            return num;
        }
    }
}
