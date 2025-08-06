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
            //int[] array1 = new int[3];
            //array1[0] = 10;
            //array1[1] = 20;
            //array1[2] = 30;

            //Console.WriteLine("Array1:");
            //foreach (int value in array1)
            //{
            //    Console.WriteLine(value);
            //}

            //int[] array2 = new int[] { 40, 50, 60 };

            //Console.WriteLine("\nArray2:");
            //foreach (int value in array2)
            //{
            //    Console.WriteLine(value);
            //}

            //int[] array3 = { 70, 80, 90 };

            //Console.WriteLine("\nArray3:");
            //foreach (int value in array3)
            //{
            //    Console.WriteLine(value);
            //}
            ////out of bounds Exception
            //Console.WriteLine(array3[3]);
            #endregion
            #region Problem2
            //int[] arr1 = { 1, 2, 3, 4, 5 };

            //int[] arr2 = arr1;

            //arr2[0] = 100;

            //Console.WriteLine("shallow copy:");

            //Console.WriteLine("arr1:");
            //foreach (int item in arr1)
            //{
            //    Console.Write(item + " ");
            //}

            //Console.WriteLine("\narr2:");
            //foreach (int item in arr2)
            //{
            //    Console.Write(item + " ");
            //}

            //int[] arr3 = (int[])arr1.Clone();

            //arr3[1] = 200;

            //Console.WriteLine("\n\ndeep copy:");

            //Console.WriteLine("arr1:");
            //foreach (int item in arr1)
            //{
            //    Console.Write(item + " ");
            //}

            //Console.WriteLine("\narr3:");
            //foreach (int item in arr3)
            //{
            //    Console.Write(item + " ");
            //}
            #endregion
            #region Problem3
            //int[,] grades = new int[3, 3];
            //for (int student = 0; student < 3; student++)
            //{
            //    Console.WriteLine($"Enter grades for Student {student + 1}:");
            //    for (int subject = 0; subject < 3; subject++)
            //    {
            //        Console.Write($"  Subject {subject + 1}: ");
            //        while (!int.TryParse(Console.ReadLine(), out grades[student, subject]))
            //        {
            //            Console.Write("    Invalid input. Please enter an integer: ");
            //        }
            //    }
            //}
            //Console.WriteLine("\nStudent Grades:");
            //for (int student = 0; student < 3; student++)
            //{
            //    Console.Write($"Student {student + 1}: ");
            //    for (int subject = 0; subject < 3; subject++)
            //    {
            //        Console.Write($"Subject {subject+1}:{grades[student, subject]} ");
            //    }
            //    Console.WriteLine();
            //}
            #endregion
            #region Problem4
            //int[] arr = { 5, 2, 8, 1, 9 };
            //Console.WriteLine("Original array:");
            //PrintArray(arr);
            //Console.WriteLine("\n1. Sort: Sorting the array in ascending order:");
            //Array.Sort(arr);
            //PrintArray(arr);
            //Console.WriteLine("\n2. Reverse: Reversing the array:");
            //Array.Reverse(arr);
            //PrintArray(arr);
            //Console.WriteLine("\n3. IndexOf: Finding index of element 8:");
            //int index = Array.IndexOf(arr, 8);
            //Console.WriteLine($"Index of 8: {index}");
            //Console.WriteLine("\n4. Copy: Copying the first 3 elements to a new array:");
            //int[] CopiedArray = new int[3];
            //Array.Copy(arr, CopiedArray, 3);
            //PrintArray(CopiedArray);
            //Console.WriteLine("\n5. Clear: Clearing 2 elements starting at index 1.");
            //Array.Clear(arr, 1, 2);
            //PrintArray(arr);

            //static void PrintArray(int[] arr)
            //{
            //    foreach (int item in arr)
            //    {
            //        Console.Write(item + " ");
            //    }
            //    Console.WriteLine();
            //}
            #endregion
            #region Problem5
            //int[] numbers = { 10, 20, 30, 40, 50 };

            //Console.WriteLine("Using for loop:");
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    Console.Write(numbers[i] + " ");
            //}

            //Console.WriteLine("\n\nUsing foreach loop:");
            //foreach (int num in numbers)
            //{
            //    Console.Write(num + " ");
            //}

            //Console.WriteLine("\n\nUsing while loop(Reverse):");
            //int index = numbers.Length - 1;
            //while (index >= 0)
            //{
            //    Console.Write(numbers[index] + " ");
            //    index--;
            //}
            #endregion
            #region Problem6
            //int number;
            //bool isValid;

            //do
            //{
            //    Console.Write("Enter a positive odd number: ");
            //    string input = Console.ReadLine();
            //    isValid = int.TryParse(input, out number);
            //    if (!isValid)
            //    {
            //        Console.WriteLine("Invalid input. Please enter a valid integer.");
            //    }
            //    else if (number <= 0)
            //    {
            //        Console.WriteLine("Number must be positive.");
            //        isValid = false;
            //    }
            //    else if (number % 2 == 0)
            //    {
            //        Console.WriteLine("Number must be odd.");
            //        isValid = false;
            //    }
            //} while (!isValid);
            //Console.WriteLine($"You entered a valid positive odd number");
            #endregion
            #region Problem7
            //int[,] matrix = {
            //{ 1, 2, 3 },
            //{ 4, 5, 6 },
            //{ 7, 8, 9 }
            //};

            //Console.WriteLine("2D Array in matrix format:");

            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    for (int col = 0; col < matrix.GetLength(1); col++)
            //    {
            //        Console.Write(matrix[row, col] + "\t");
            //    }
            //    Console.WriteLine();
            //}
            #endregion
            #region Problem8
            //Console.Write("Enter a month number (1-12): ");
            //string input = Console.ReadLine();

            //if (int.TryParse(input, out int monthNumber))
            //{
            //    Console.WriteLine("\nUsing if:");
            //    if (monthNumber == 1)
            //        Console.WriteLine("January");
            //    else if (monthNumber == 2)
            //        Console.WriteLine("February");
            //    else if (monthNumber == 3)
            //        Console.WriteLine("March");
            //    else if (monthNumber == 4)
            //        Console.WriteLine("April");
            //    else if (monthNumber == 5)
            //        Console.WriteLine("May");
            //    else if (monthNumber == 6)
            //        Console.WriteLine("June");
            //    else if (monthNumber == 7)
            //        Console.WriteLine("July");
            //    else if (monthNumber == 8)
            //        Console.WriteLine("August");
            //    else if (monthNumber == 9)
            //        Console.WriteLine("September");
            //    else if (monthNumber == 10)
            //        Console.WriteLine("October");
            //    else if (monthNumber == 11)
            //        Console.WriteLine("November");
            //    else if (monthNumber == 12)
            //        Console.WriteLine("December");
            //    else
            //        Console.WriteLine("Invalid month number.");
            //    Console.WriteLine("\nUsing switch:");
            //    switch (monthNumber)
            //    {
            //        case 1: Console.WriteLine("January"); break;
            //        case 2: Console.WriteLine("February"); break;
            //        case 3: Console.WriteLine("March"); break;
            //        case 4: Console.WriteLine("April"); break;
            //        case 5: Console.WriteLine("May"); break;
            //        case 6: Console.WriteLine("June"); break;
            //        case 7: Console.WriteLine("July"); break;
            //        case 8: Console.WriteLine("August"); break;
            //        case 9: Console.WriteLine("September"); break;
            //        case 10: Console.WriteLine("October"); break;
            //        case 11: Console.WriteLine("November"); break;
            //        case 12: Console.WriteLine("December"); break;
            //        default: Console.WriteLine("Invalid month number."); break;
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Invalid input. Please enter a number.");
            //}
            #endregion
            #region Problem9
            //int[] numbers = { 5, 2, 8, 3, 2, 7, 2 };
            //Console.WriteLine("Original Array:");
            //PrintArray(numbers);
            //Array.Sort(numbers);
            //Console.WriteLine("\nSorted Array:");
            //PrintArray(numbers);
            //Console.Write("\nEnter a value to search: ");
            //string input = Console.ReadLine();

            //if (int.TryParse(input, out int searchValue))
            //{
            //    int firstIndex = Array.IndexOf(numbers, searchValue);
            //    int lastIndex = Array.LastIndexOf(numbers, searchValue);
            //    if (firstIndex != -1)
            //    {
            //        Console.WriteLine($"\nFirst occurrence of {searchValue}: Index {firstIndex}");
            //        Console.WriteLine($"Last occurrence of {searchValue}: Index {lastIndex}");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"\nValue {searchValue} not found in the array.");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Invalid input. Please enter an integer.");
            //}
            //static void PrintArray(int[] arr)
            //{
            //    foreach (int num in arr)
            //    {
            //        Console.Write(num + " ");
            //    }
            //    Console.WriteLine();
            //}
            #endregion
            #region Problem10
            //int[] numbers = { 5, 10, 15, 20, 25 };
            //int SumFor = 0;
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    SumFor += numbers[i];
            //}
            //Console.WriteLine("Sum using for loop: " + SumFor);
            //int SumForeach = 0;
            //foreach (int num in numbers)
            //{
            //    SumForeach += num;
            //}
            //Console.WriteLine("Sum using foreach loop: " + SumForeach);
            #endregion
            #region problem11
            //Console.Write("Enter a number (1-7): ");
            //string input = Console.ReadLine();

            //if (int.TryParse(input, out int dayNumber) && dayNumber >= 1 && dayNumber <= 7)
            //{
            //    DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayNumber.ToString());
            //    Console.WriteLine($"The day is: {day}");
            //}
            //else
            //{
            //    Console.WriteLine("Invalid input. Please enter a number from 1 to 7.");
            //}
            #endregion
        }
        enum DayOfWeek
        {
            Monday = 1,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
    }
}