using System;
using System.Text;
using AlgorithmAction.Algorithm;

namespace AlgorithmAction
{
    class Program
    {
        static void Main(string[] args)
        {
            //StringShiftTest();
            //StringReversTest();

            //StringContainTest();
            //StringContainQuickSortTest();
            //StringContainHashTest();
            //StringContainPrimeTest();
            //FindTopKHeapTest();
            FindTopKQuickSortTest();
        }

        #region string shift
        private static void StringShiftTest()
        {
            string input = Console.ReadLine();
            byte[] arr = System.Text.Encoding.UTF8.GetBytes(input);

            string inchar = Console.ReadLine();
            int shift = Convert.ToInt32(inchar);
            StringShift stringShift = new StringShift();
            stringShift.LeftShiftM(ref arr, arr.Length, shift);

            Console.WriteLine("output: " + Encoding.UTF8.GetString(arr));
        }

        private static void StringReversTest()
        {
            string input = Console.ReadLine();
            byte[] arr = System.Text.Encoding.UTF8.GetBytes(input);

            string inchar = Console.ReadLine();
            int shift = Convert.ToInt32(inchar);
            StringReverse stringShift = new StringReverse();
            stringShift.LeftShift(ref arr, arr.Length, shift);

            Console.WriteLine("output: " + Encoding.UTF8.GetString(arr));
        }

        #endregion


        #region string contains

        private static void StringContainTest()
        {
            Console.WriteLine("input long string: ");
            string longStr = Console.ReadLine();
            Console.WriteLine("input short string: ");
            string shortStr = Console.ReadLine();

            StringContains stringContains = new StringContains();
            int ret = stringContains.CompareString(longStr, shortStr);
        }


        private static void StringContainQuickSortTest()
        {
            Console.WriteLine("input long string: ");
            string longStr = Console.ReadLine();
            Console.WriteLine("input short string: ");
            string shortStr = Console.ReadLine();

            StringContainQuickSort stringContains = new StringContainQuickSort();
            stringContains.CompareString(longStr, shortStr);
        }


        private static void StringContainHashTest()
        {
            Console.WriteLine("input long string: ");
            string longStr = Console.ReadLine();
            Console.WriteLine("input short string: ");
            string shortStr = Console.ReadLine();

            StringContainHash stringContains = new StringContainHash();
            stringContains.CompareString(longStr, shortStr);    
        }

        private static void StringContainPrimeTest()
        {
            Console.WriteLine("input long string: ");
            string longStr = Console.ReadLine();
            Console.WriteLine("input short string: ");
            string shortStr = Console.ReadLine();

            StringContainPrime stringContains = new StringContainPrime();
            stringContains.CompareString(longStr, shortStr);    
        }

        #endregion

        #region find top K

        private static void FindTopKHeapTest()
        {
            //int[] arr = new int[] {9, 8, 6, 4, 1, 2, 3, 16};
            //int k = 3;
            Console.WriteLine("Please input the array with space as split: ");
            string input = Console.ReadLine();

            Console.WriteLine("please input the K: ");
            int k = Convert.ToInt32(Console.ReadLine());
            string[] arrStr = input.Split(' ');
            int[] arr = new int[arrStr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Convert.ToInt32(arrStr[i]);
            }
            FindTopKHeap heap = new FindTopKHeap();
            heap.FindMinimumK(arr, arr.Length, k);
            Console.WriteLine("The " + k + " minimum numbers in array are: ");
            for (int i = 0; i < k; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("The array is: ");
            foreach (var i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }


        private static void FindTopKQuickSortTest()
        {
            Console.WriteLine("Please input the array with space as split: ");
            string input = Console.ReadLine();

            Console.WriteLine("please input the K: ");
            int k = Convert.ToInt32(Console.ReadLine());
            string[] arrStr = input.Split(' ');
            int[] arr1 = new int[arrStr.Length];
            int[] arr2 = new int[arrStr.Length];
            int[] arr3 = new int[arrStr.Length];
            for (int i = 0; i < arrStr.Length; i++)
            {
                arr1[i] = Convert.ToInt32(arrStr[i]);
                arr2[i] = arr1[i];
                arr3[i] = arr1[i];
            }



            FindTopKQuickSort heap = new FindTopKQuickSort();
            bool flag1 = heap.MedianSelect(ref arr1, 0, arr1.Length - 1, k);
            bool flag2 = heap.RandSelect(ref arr2, 0, arr1.Length - 1, k);
            bool flag3 = heap.KthSelect(ref arr3, 0, arr1.Length - 1, k);
            Console.WriteLine("The " + k + " minimum numbers with median select in array are: ");
            for (int i = 0; i < k; i++)
            {
                Console.Write(arr1[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("The array is: ");
            foreach (var i in arr1)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Console.WriteLine("The " + k + " minimum numbers with random select in array are: ");
            for (int i = 0; i < k; i++)
            {
                Console.Write(arr2[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("The array is: ");
            foreach (var i in arr2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Console.WriteLine("The " + k + " minimum numbers with kth select in array are: ");
            for (int i = 0; i < k; i++)
            {
                Console.Write(arr3[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("The array is: ");
            foreach (var i in arr3)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        #endregion
    }
}
