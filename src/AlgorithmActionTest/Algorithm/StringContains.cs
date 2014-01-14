using System;

namespace AlgorithmAction.Algorithm
{
    public class StringContains
    {
        public int CompareString(string longStr, string shortStr)
        {
            int i, j;
            for (i = 0; i < shortStr.Length; i++ )
            {
                for (j = 0; j < longStr.Length; j++)
                {
                    if (longStr[j] == shortStr[i])
                    {
                        break;
                    }
                }

                if (j == longStr.Length)
                {
                    Console.WriteLine("false");
                    return 0;
                }
            }

            Console.WriteLine("true");
            return 1;
        }
    }
}
