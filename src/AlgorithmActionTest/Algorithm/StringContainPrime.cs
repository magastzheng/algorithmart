using System;

namespace AlgorithmAction.Algorithm
{
    public class StringContainPrime
    {
        private int[] _primeNumber = new[]
        {
            2,
            3,
            5,
            7,
            11,
            13,
            17,
            19,
            23,
            29,
            31,
            37,
            41,
            43,
            47,
            53,
            59,
            61,
            67,
            71,
            73,
            79,
            83,
            89,
            97,
            101};

        public void CompareString(string longStr, string shortStr)
        {
            char[] longChars = longStr.ToUpper().ToCharArray();
            char[] shortChars = shortStr.ToUpper().ToCharArray();

            Compare(longChars, shortChars);
        }

        public int Compare(char[] longStr, char[] shortStr)
        {
            long product = 1;
            for (int i = 0, len = longStr.Length; i < len; i++)
            {
                int index = longStr[i] - 'A';
                product = product*_primeNumber[index];
            }

            int j = 0, shortLen = shortStr.Length;
            for (; j < shortLen; j++)
            {
                int index = shortStr[j] - 'A';

                if (product % _primeNumber[index] != 0)
                {
                    break;
                }
            }

            if (shortLen == j)
            {
                Console.WriteLine("true");
                return 0;
            }
            else
            {
                Console.WriteLine("false");
            }

            return -1;
        }
    }
}
