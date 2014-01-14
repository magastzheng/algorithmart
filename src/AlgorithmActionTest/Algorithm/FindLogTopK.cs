using System.IO;
using System.Linq;
using System.Text;

namespace AlgorithmAction.Algorithm
{
    public class NodeSpace
    {
        public int Count { get; set; }
        public string Word { get; set; }
    }

    public class NodeNoSpace : NodeSpace
    {

        public NodeNoSpace Next { get; set; }
    }

    public class NodeHasSpace : NodeSpace
    {
        public NodeHasSpace Next { get; set; }
    }

    public class FindLogTopK
    {
        public static int Hashlen = 2807303;
        private NodeNoSpace[] _head = new NodeNoSpace[Hashlen];

        public FindLogTopK()
        {
            Initialize();
        }

        private void Initialize()
        {
            for (int i = 0; i < Hashlen; i++)
            {
                _head[i] = null;
            }
        }

        private int HasFunction(string word)
        {
            int value = 0;
            foreach (var character in word)
            {
                value = value*31 + character;
                if (value > Hashlen)
                {
                    value = value%Hashlen;
                }
            }

            return value;
        }

        public void AppendWord(string word)
        {
            int index = HasFunction(word);
            NodeNoSpace p = _head[index];
            while (p != null)
            {
                if (p.Word == word)
                {
                    p.Count++;
                    return;
                }

                p = p.Next;
            }

            NodeNoSpace q = new NodeNoSpace {Count = 1, Word = word, Next = _head[index]};
            _head[index] = q;
        }

        public void WriteToFile()
        {
            StreamWriter streamWriter = new StreamWriter("result.txt", false, Encoding.UTF8);
            int i = 0;
            while (i < Hashlen)
            {
                for (var p = _head[i]; p != null; p = p.Next)
                {
                    streamWriter.WriteLine("{0} {1}", p.Word, p.Count);
                }
                i++;
            }
            streamWriter.Close();
        }

        private void Swap(NodeHasSpace left, NodeHasSpace right)
        {
            if (left.Count != right.Count)
            {
                int temp = left.Count;
                left.Count = right.Count;
                right.Count = temp;
            }

            if (left.Word != right.Word)
            {
                string temp = left.Word;
                left.Word = right.Word;
                right.Word = temp;
            }
        }

        public void ShiftDown(NodeHasSpace[] heap, int i, int len)
        {
            int minIndex = -1;
            int left = 2*i;
            int right = 2*i + 1;
            if (left <= len && heap[left].Count < heap[i].Count)
            {
                minIndex = left;
            }
            else
            {
                minIndex = i;
            }

            if (right <= len && heap[right].Count < heap[minIndex].Count)
            {
                minIndex = right;
            }

            if (minIndex != i)
            {
                Swap(heap[i], heap[minIndex]);
                ShiftDown(heap, minIndex, len);
            }
        }

        public void BuildMinHeap(NodeHasSpace[] heap, int len)
        {
            if (heap == null)
                return;
            int index = len/2;
            for (int i = index; i >= 1; i--)
            {
                ShiftDown(heap, i, len);
            }
        }

        public string HandleSymbol(string word)
        {
            return new string(word.Where(c => char.IsLetterOrDigit(c)).ToArray());
        }
    }
}
