using System;

namespace AlgorithmAction.Algorithm
{
    public class StringContainQuickSort
    {
        public void CompareString(string longStr, string shortStr)
        {
            char[] longChars = longStr.ToCharArray();
            char[] shortChars = shortStr.ToCharArray();

            QuickSort(ref longChars, 0, longChars.Length - 1);
            QuickSort(ref shortChars, 0, shortChars.Length - 1);
            Compare(longChars, shortChars);
        }

        private void Compare(char[] longStr, char[] shorStr)
        {
            int posLong = 0;
            int posShort = 0;
            while (posShort < shorStr.Length && posLong < longStr.Length)
            {
                while (longStr[posLong] < shorStr[posShort] && posLong < longStr.Length)
                    posLong++;

                if (longStr[posLong] != shorStr[posShort])
                    break;

                posShort++;
            }

            if (posShort == shorStr.Length)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }

        private void Swap(ref char left, ref char right)
        {
            char temp = left;
            left = right;
            right = temp;
        }

        private int Partition(char[] str, int lo, int hi)
        {
            char key = str[hi];
            int i = lo - 1;
            for (int j = lo; j < hi; j++)
            {
                if (str[j] <= key)
                {
                    i++;
                    Swap(ref str[i], ref str[j]);
                }
            }

            Swap(ref str[i+1], ref str[hi]);

            return i + 1;
        }

        private void QuickSort(ref char[] str, int lo, int hi)
        {
            if (lo < hi)
            {
                int k = Partition(str, lo, hi);
                QuickSort(ref str, lo, k - 1);
                QuickSort(ref str, k + 1, hi);
            }
        }
    }
}
