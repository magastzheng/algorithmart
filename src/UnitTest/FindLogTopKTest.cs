using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using AlgorithmAction.Algorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmAction.UnitTest
{
    [TestClass]
    public class FindLogTopKTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            FindLogTopK findLogTopK = new FindLogTopK();
            
            StreamReader streamReader = new StreamReader("string.txt", Encoding.UTF8);
            string allString = streamReader.ReadToEnd();
            string[] words = allString.Split(' ');
            foreach (var word in words)
            {
                string escapeSymbol = findLogTopK.HandleSymbol(word);
                if (escapeSymbol.Length > 0)
                {
                    findLogTopK.AppendWord(escapeSymbol);
                }
            }
            streamReader.Close();

            findLogTopK.WriteToFile();

            int n = 10;
            NodeHasSpace[] heap = new NodeHasSpace[n + 1];

            StreamReader sr = new StreamReader("result.txt", Encoding.UTF8);
            for (int i = 1; i <= n; i++)
            {
                string line = sr.ReadLine();
                var ws = line.Split(' ');

                heap[i] = new NodeHasSpace {Count = Convert.ToInt32(ws[1]), Word = ws[0]};
            }

            findLogTopK.BuildMinHeap(heap, n);
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var ws = line.Split(' ');
                int count = Convert.ToInt32(ws[1]);
                if (count > heap[1].Count)
                {
                    heap[1].Count = count;
                    heap[1].Word = ws[0];

                    findLogTopK.ShiftDown(heap, 1, n);
                }
            }

            sr.Close();

            for (int k = 1; k <= n; k++)
            {
                string output = string.Format("{0} {1}", heap[k].Count, heap[k].Word);
                Trace.WriteLine(output);
            }
        }
    }
}
