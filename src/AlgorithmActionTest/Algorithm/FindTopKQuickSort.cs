using System;

namespace AlgorithmAction.Algorithm
{
    public class FindTopKQuickSort
    {
        private int MyRand(int low, int high)
        {
            int size = high - low + 1;
            Random rd = new Random();
            return low + rd.Next()%size;
        }

        private void Swap(ref int left, ref int right)
        {
            int temp = left;
            left = right;
            right = temp;
        }
        //The quicksort in place version - http://zh.wikipedia.org/wiki/%E5%BF%AB%E9%80%9F%E6%8E%92%E5%BA%8F
        private int Partition(ref int[] arr, int left, int right)
        {
            //use the right element as pivot
            int pivot = arr[right];
            //pos store the right place of pivot
            int pos = left - 1; 
            for (int index = left; index < right; index++)
            {
                if (arr[index] <= pivot)
                {
                    Swap(ref arr[++pos], ref arr[index]);
                }
            }

            //put the pivot into its place
            Swap(ref arr[++pos], ref arr[right]);

            return pos;
        }

        public bool MedianSelect(ref int[] arr, int left, int right, int k)
        {
            if (k - 1 > right || k - 1 < left)
            {
                return false;
            }

            int midIndex = (left + right)/2;
            if (arr[left] < arr[midIndex])
            {
                Swap(ref arr[left], ref arr[midIndex]);
            }
            if (arr[right] < arr[midIndex])
            {
                Swap(ref arr[right], ref arr[midIndex]);
            }
            if (arr[right] < arr[left])
            {
                Swap(ref arr[right], ref arr[left]);
            }

            Swap(ref arr[left], ref arr[right]);

            int pos = Partition(ref arr, left, right);
            if (pos == k - 1)
            {
                return true;
            }
            else if (pos > k - 1)
            {
                return MedianSelect(ref arr, left, pos - 1, k);
            }
            else
            {
                return MedianSelect(ref arr, pos + 1, right, k);
            }
        }

        public bool RandSelect(ref int[] arr, int left, int right, int k)
        {
            if (k - 1 > right || k - 1 < left)
            {
                return false;
            }

            int index = MyRand(left, right);
            Swap(ref arr[index], ref arr[right]);

            int pos = Partition(ref arr, left, right);
            if (pos == k - 1)
            {
                return true;
            }
            else if (pos > k - 1)
            {
                return RandSelect(ref arr, left, pos - 1, k);
            }
            else
            {
                return RandSelect(ref arr, pos + 1, right, k);
            }
        }

        public bool KthSelect(ref int[] arr, int left, int right, int k)
        {
            if (k - 1 > right || k - 1 < left)
                return false;

            int pos = Partition(ref arr, left, right);
            if (pos == k - 1)
                return true;
            else if (pos > k - 1)
            {
                return KthSelect(ref arr, left, pos - 1, k);
            }
            else
            {
                return KthSelect(ref arr, pos + 1, right, k);
            }
        }
    }
}
