using System;

namespace Task1
{
    internal static class Program
    {
        private static int GetSign(int[] a)
        {
            var result = true;
            foreach (var i in a)
            {
                if (i == 0)
                    return 0;

                if (i < 0)
                    result = !result;
            }

            return result ? 1 : -1;
        }

        private static void Main(string[] args)
        {
            Console.WriteLine(GetSign(new[] { 1, -2, -3, 5 }));
            Console.WriteLine(GetSign(new[] { 1, 2, 3, -5 }));
            Console.WriteLine(GetSign(new[] { 1, 2, 0, -5 }));
        }
    }
}
