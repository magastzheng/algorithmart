using System.Diagnostics;

namespace AlgorithmAction.Algorithm
{
    public class StringShift
    {
        public void LeftShiftM(ref byte[] arr, int len, int shift)
        {
            while (shift-- > 0)
            {
                leftShiftOne(ref arr, len);
            }
        }

        private void leftShiftOne(ref byte[] arr, int len)
        {
            Debug.Assert(arr != null);
            byte temp = arr[0];
            int i = 1;

            while (i < len)
            {
                arr[i - 1] = arr[i];
                i++;
            }
            arr[len - 1] = temp;
        }
    }
}
