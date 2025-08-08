using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Problem1
            //try
            //{
            //    Console.Write("Enter first number: ");
            //    int num1 = int.Parse(Console.ReadLine());

            //    Console.Write("Enter second number: ");
            //    int num2 = int.Parse(Console.ReadLine());

            //    int result = num1 / num2;
            //    Console.WriteLine($"Result: {result}");
            //}
            //catch (DivideByZeroException)
            //{
            //    Console.WriteLine("Error: Cannot divide by zero.");
            //}
            //finally
            //{
            //    Console.WriteLine("Operation complete");
            //}
            #endregion
            #region Problem2
            //void TestDefensiveCode()
            //{
            //    Console.Write("Enter positive integer X: ");
            //    int x = int.Parse(Console.ReadLine());

            //    Console.Write("Enter positive integer Y (greater than 1): ");
            //    int y = int.Parse(Console.ReadLine());

            //    if (x <= 0 || y <= 1)
            //    {
            //        Console.WriteLine("Invalid input. X must be positive and Y must be greater than 1.");
            //        return;
            //    }

            //    Console.WriteLine($"X: {x}, Y: {y}");
            //}
            //TestDefensiveCode();
            #endregion
            #region Problem3
            //int? NullableInt = null;
            //int result = NullableInt ?? 10;
            //Console.WriteLine($"Value after null-coalescing: {result}");

            //NullableInt = 20;

            //if (NullableInt.HasValue)
            //{
            //    Console.WriteLine($"HasValue: {NullableInt.Value}");
            //}
            //else
            //{
            //    Console.WriteLine("No value present.");
            //}
            #endregion
            #region Problem4
            //int[] arr = new int[5] { 1, 2, 3, 4, 5 };
            //try
            //{
            //    Console.WriteLine(arr[10]);
            //}
            //catch (IndexOutOfRangeException)
            //{
            //    Console.WriteLine("Error: Index out of range.");
            //}
            #endregion
            #region Problem5
            //int[,] matrix = new int[3, 3];
            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        Console.Write($"Enter value for [{i},{j}]: ");
            //        matrix[i, j] = int.Parse(Console.ReadLine());
            //    }
            //}

            //for (int i = 0; i < 3; i++)
            //{
            //    int RowSum = 0, ColSum = 0;
            //    for (int j = 0; j < 3; j++)
            //    {
            //        RowSum += matrix[i, j];
            //        ColSum += matrix[j, i];
            //    }
            //    Console.WriteLine($"Row {i} sum: {RowSum}, Column {i} sum: {ColSum}");
            //}
            #endregion
            #region Problem6
            //int[][] jagged = new int[3][];
            //jagged[0] = new int[2];
            //jagged[1] = new int[3];
            //jagged[2] = new int[1];

            //for (int i = 0; i < jagged.Length; i++)
            //{
            //    for (int j = 0; j < jagged[i].Length; j++)
            //    {
            //        Console.Write($"Enter value for row {i}, element {j}: ");
            //        jagged[i][j] = int.Parse(Console.ReadLine());
            //    }
            //}

            //for (int i = 0; i < jagged.Length; i++)
            //{
            //    Console.Write("Row " + i + ": ");
            //    foreach (var val in jagged[i])
            //        Console.Write(val + " ");
            //    Console.WriteLine();
            //}
            #endregion
            #region Problem7
            //string? input = Console.ReadLine();
            //string name = input != null ? input : "Default";
            //Console.WriteLine($"Hello, {name}");
            //Console.WriteLine($"Length: {input!.Length}");
            #endregion
            #region Problem8
            //int number = 42;
            //object boxed = number;
            //try
            //{
            //    int unboxed = (int)boxed; // Valid
            //    Console.WriteLine($"Unboxed: {unboxed}");
            //    string wrongCast = (string)boxed; // Invalid cast
            //}
            //catch (InvalidCastException)
            //{
            //    Console.WriteLine("Error: Invalid cast.");
            //}
            #endregion
            #region Problem9
            //void SumAndMultiply(int a, int b, out int sum, out int product)
            //{
            //    sum = a + b;
            //    product = a * b;
            //}
            //SumAndMultiply(4, 5, out int s, out int p);
            //Console.WriteLine($"Sum: {s}, Product: {p}");
            #endregion
            #region Problem10
            //void PrintMessage(string message, int times = 5)
            //{
            //    for (int i = 0; i < times; i++)
            //    {
            //        Console.WriteLine(message);
            //    }
            //}
            //PrintMessage("Hello", times: 3);
            //PrintMessage("World");
            #endregion
            #region Problem11
            //int[]? numbers = null;
            //Console.WriteLine($"Array Length: {numbers?.Length}");
            //numbers = new int[] { 1, 2, 3 };
            //Console.WriteLine($"Array Length after assignment: {numbers?.Length}");
            #endregion
            #region Problem12
            //Console.Write("Enter a day of the week: ");
            //string day = Console.ReadLine() ?? "";
            //int dayNumber = day.ToLower() switch
            //{
            //    "monday" => 1,
            //    "tuesday" => 2,
            //    "wednesday" => 3,
            //    "thursday" => 4,
            //    "friday" => 5,
            //    "saturday" => 6,
            //    "sunday" => 7,
            //    _ => -1
            //};
            //Console.WriteLine(dayNumber == -1 ? "Invalid day" : $"Day number: {dayNumber}");
            #endregion
            #region Problem13
            //int SumArray(params int[] numbers)
            //{
            //    int sum = 0;
            //    foreach (int num in numbers)
            //        sum += num;
            //    return sum;
            //}
            //Console.WriteLine(SumArray(1, 2, 3, 4));
            //int[] arr = { 10, 20, 30 };
            //Console.WriteLine(SumArray(arr));
            #endregion
        }
    }
}