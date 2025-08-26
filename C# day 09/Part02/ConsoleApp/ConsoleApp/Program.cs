using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        #region Problem 1
        //int[] numbers = { 1, 2, 3, 4, 5 };
        //string[] words = { "one", "two", "three" };
        //var reversedNumbers = Helper.ReverseArray(numbers);
        //var reversedWords = Helper.ReverseArray(words);
        //Console.WriteLine("Reversed Numbers: " + string.Join(", ", reversedNumbers));
        //Console.WriteLine("Reversed Words: " + string.Join(", ", reversedWords));
        #endregion

        #region Problem 2
        //MyStack<int> stack = new MyStack<int>();
        //stack.Push(10);
        //stack.Push(20);
        //stack.Push(30);
        //Console.WriteLine("Top element: " + stack.Peek());
        //Console.WriteLine("Popped element: " + stack.Pop());
        //Console.WriteLine("Top element after Pop: " + stack.Peek());
        #endregion

        #region Problem 3
        //int[] numbers = { 1, 2, 3, 4, 5 };
        //ArrayUtils.SwapElements(numbers, 0, 4);
        //numbers becomes { 5, 2, 3, 4, 1 }
        #endregion

        #region Problem 4
        //int[] numbers = { 3, 1, 4, 1, 5, 9, 2, 6 };
        //int max = ArrayUtils.FindMaxElement(numbers);
        #endregion

    }


    #region Problem 1 classes
    //class Helper
    //{
    //    public static T[] ReverseArray<T>(T[] inputArray)
    //    {
    //        T[] result = new T[inputArray.Length];
    //        for (int i = 0, j = inputArray.Length - 1; i < inputArray.Length; i++, j--)
    //        {
    //            result[i] = inputArray[j];
    //        }
    //        return result;
    //    }
    //}
    #endregion

    #region Problem 2 classes
    //class MyStack<T>
    //{
    //    private List<T> items = new List<T>();
    //    public void Push(T item) => items.Add(item);
    //    public T Pop()
    //    {
    //        if (items.Count == 0) throw new InvalidOperationException("Stack is empty.");
    //        T value = items[^1]; // last element
    //        items.RemoveAt(items.Count - 1);
    //        return value;
    //    }
    //    public T Peek()
    //    {
    //        if (items.Count == 0) throw new InvalidOperationException("Stack is empty.");
    //        return items[^1];
    //    }
    //    public int Count => items.Count;
    //}
    #endregion

    #region Problem 3 classes
    //public static class ArrayUtils
    //{
    //    public static void SwapElements<T>(T[] array, int index1, int index2)
    //    {
    //        if (array == null)
    //            throw new ArgumentNullException(nameof(array));

    //        if (index1 < 0 || index1 >= array.Length)
    //            throw new ArgumentOutOfRangeException(nameof(index1));

    //        if (index2 < 0 || index2 >= array.Length)
    //            throw new ArgumentOutOfRangeException(nameof(index2));

    //        // Swap the elements
    //        T temp = array[index1];
    //        array[index1] = array[index2];
    //        array[index2] = temp;
    //    }
    //}
    #endregion

    #region Problem 4 classes
    //public static class ArrayUtils
    //{
    //    public static T FindMaxElement<T>(T[] array) where T : IComparable<T>
    //    {
    //        if (array == null || array.Length == 0)
    //            throw new ArgumentException("Array cannot be null or empty");
    //        T max = array[0];
    //        for (int i = 1; i < array.Length; i++)
    //        {
    //            if (array[i].CompareTo(max) > 0)
    //            {
    //                max = array[i];
    //            }
    //        }
    //        return max;
    //    }
    //}
    #endregion

}

