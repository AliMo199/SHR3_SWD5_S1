using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Problem1
            //Console.Write("Enter a positive integer: ");
            //int limit = int.Parse(Console.ReadLine());

            //for (int i = 1; i <= limit; i++)
            //{
            //    Console.Write(i);
            //    if (i < limit) Console.Write(", ");
            //}
            #endregion
            #region Problem2
            //Console.Write("Enter an integer: ");
            //int number = int.Parse(Console.ReadLine());

            //for (int i = 1; i <= 12; i++)
            //{
            //    Console.Write(number * i);
            //    if (i < 12) Console.Write(", ");
            //}
            #endregion
            #region Problem3
            //Console.Write("Enter a number: ");
            //int max = int.Parse(Console.ReadLine());

            //for (int i = 2; i <= max; i += 2)
            //{
            //    Console.Write(i);
            //    if (i + 2 <= max) Console.Write(", ");
            //}
            #endregion
            #region Problem4
            //Console.Write("Enter base number: ");
            //int baseNum = int.Parse(Console.ReadLine());
            //Console.Write("Enter exponent: ");
            //int exponent = int.Parse(Console.ReadLine());
            //int result = 1;
            //for (int i = 0; i < exponent; i++)
            //{
            //    result *= baseNum;
            //}
            //Console.WriteLine($"Result: {result}");
            #endregion
            #region Problem5
            //Console.Write("Enter a string: ");
            //string input = Console.ReadLine();
            //char[] chars = input.ToCharArray();
            //Array.Reverse(chars);
            //string reversed = new string(chars);
            //Console.WriteLine($"Reversed: {reversed}");
            #endregion
            #region Problem6
            //Console.Write("Enter an integer: ");
            //int num = int.Parse(Console.ReadLine());
            //int reversed = 0;
            //while (num > 0)
            //{
            //    int digit = num % 10;
            //    reversed = reversed * 10 + digit;
            //    num /= 10;
            //}
            //Console.WriteLine($"Reversed: {reversed}");
            #endregion
            #region Problem7
            //Console.Write("Enter numbers separated by commas: ");
            //string[] input = Console.ReadLine().Split(',');
            //int[] arr = Array.ConvertAll(input, int.Parse);
            //Dictionary<int, int> firstIndices = new();
            //int maxDistance = 0;
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (!firstIndices.ContainsKey(arr[i]))
            //    {
            //        firstIndices[arr[i]] = i;
            //    }
            //    else
            //    {
            //        int distance = i - firstIndices[arr[i]] - 1;
            //        if (distance > maxDistance)
            //        {
            //            maxDistance = distance;
            //        }
            //    }
            //}
            //Console.WriteLine($"Longest distance: {maxDistance}");
            #endregion
            #region Problem8
            //Console.Write("Enter a sentence: ");
            //string sentence = Console.ReadLine();
            //string[] words = sentence.Split(' ');
            //Array.Reverse(words);
            //string result = string.Join(" ", words);
            //Console.WriteLine(result);
            #endregion
        }
    }
}