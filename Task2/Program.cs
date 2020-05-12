using System;

namespace Task2
{
    internal static class Program
    {
        public static int Solution(string s)
        {
            const int startCharCode = 97;
            const int englishCharCount = 26;
            var charCount = new int[englishCharCount];
            for (var i = 0; i < englishCharCount; ++i)
            {
                charCount[i] = 0;
            }

            foreach (var charCode in s)
            {
                charCount[charCode - startCharCode]++;
            }

            Sort(charCount);
            var deleteCount = 0;
            for (var i = charCount.Length - 2; i >= 0; i--)
            {
                var currentCharCount = charCount[i];
                if (currentCharCount == 0)
                    break;

                var lastCharCount = charCount[i + 1];
                if (lastCharCount == 0)
                {
                    deleteCount += currentCharCount;
                    charCount[i] = 0;
                    continue;
                }

                var delta = lastCharCount - currentCharCount;
                if (delta == 0)
                {
                    deleteCount++;
                    charCount[i]--;
                }
                else if (delta < 0)
                {
                    deleteCount += -delta + 1;
                    charCount[i] += delta - 1;
                }
            }

            return deleteCount;
        }

        public static void Sort(int[] arr)
        {
            var n = arr.Length;

            for (var i = n / 2 - 1; i >= 0; i--)
                Heapify(arr, n, i);

            for (var i = n - 1; i >= 0; i--)
            {
                var temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                Heapify(arr, i, 0);
            }
        }

        private static void Heapify(int[] arr, int n, int i)
        {
            var largest = i;
            var l = 2 * i + 1;
            var r = 2 * i + 2;
            if (l < n && arr[l] > arr[largest])
                largest = l;

            if (r < n && arr[r] > arr[largest])
                largest = r;

            if (largest == i)
                return;

            var swap = arr[i];
            arr[i] = arr[largest];
            arr[largest] = swap;
            Heapify(arr, n, largest);
        }

        private static void Main(string[] args)
        {
            Console.WriteLine(Solution("aaaabbbb")); //1
            Console.WriteLine(Solution("ccaaffddecee")); //6
            Console.WriteLine(Solution("eeee")); //0
            Console.WriteLine(Solution("example")); //4
        }
    }
}
