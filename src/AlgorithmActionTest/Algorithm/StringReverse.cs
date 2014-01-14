namespace AlgorithmAction.Algorithm
{
    public class StringReverse
    {
        public void LeftShift(ref byte[] arr, int len, int shift)
        {
            shift %= len;
            Reverse(ref arr, 0, shift - 1);
            Reverse(ref arr, shift, len - 1);
            Reverse(ref arr, 0, len - 1);
        }

        private void Reverse(ref byte[] arr, int from, int to)
        {
            while (from < to)
            {
                byte temp = arr[from];
                arr[from++] = arr[to];
                arr[to--] = temp;
                //from++;
                //to--;
            }
        }
    }
}
