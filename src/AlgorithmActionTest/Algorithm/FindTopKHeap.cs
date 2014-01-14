namespace AlgorithmAction.Algorithm
{
    public class FindTopKHeap
    {
        public int FindMinimumK(int[] arr, int length, int k)
        {
            int index = 0;
            if (arr == null || length <= 0 || k <= 0)
                return -1;

            //it only needs to maintain a heap with size as k to save the memory
            BuildMaxHeap(arr, k);

            for (index = k; index < length; index++)
            {
                if (arr[0] > arr[index])
                {
                    Swap(ref arr[0], ref arr[index]);
                    MaxHeapify(arr, k, 0);
                }
            }

            return 0;
        }

        private int GetParentIndex(int current)
        {
            return (current + 1)/2 - 1;
        }

        private int GetLeftIndex(int current)
        {
            return (current + 1)*2 - 1;
        }

        private int GetRightIndex(int current)
        {
            return (current + 1)*2;
        }

        private void Swap(ref int left, ref int right)
        {
            int temp = left;
            left = right;
            right = temp;
        }

        //make the parent value greater than its children's value
        private void MaxHeapify(int[] arr, int length, int current)
        {
            if (current < 0 || arr == null || current > length)
            {
                return;
            }

            int left = GetLeftIndex(current);
            int right = GetRightIndex(current);

            int largest = -1;

            //if current value is less than its left children, then the largest is the left
            if (left < length && arr[current] < arr[left])
            {
                largest = left;
            }
            else
            {
                largest = current;
            }

            //if right value is greater than the largest, then assign largest as right
            if (right < length && arr[largest] < arr[right])
            {
                largest = right;
            }

            if (largest != current)
            {
                Swap(ref arr[largest], ref arr[current]);

                //recurse the subheap
                MaxHeapify(arr, length, largest);
            }
        }

        private int BuildMaxHeap(int[] arr, int k)
        {
            if (arr == null)
            {
                return -1;
            }

            int length = k;
            int middle = length/2;

            for (int i = middle; i >= 0; i--)
            {
                MaxHeapify(arr, length, i);
            }

            return 0;
        }
    }
}
