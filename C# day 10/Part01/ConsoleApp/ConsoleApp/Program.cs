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

    }

    #region Problem 1
    public class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
    public class SortingAlgorithm<T> where T : IComparable<T>
    {
        public void Sort(T[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i].CompareTo(array[j]) > 0)
                    {
                        T temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }
    
    #endregion
    
    #region Problem 2
    public class SortingTwo<T>
    {
        public void Sort(T[] array, Comparison<T> comparison)
        {
            Array.Sort(array, comparison);
        }
    }
    #endregion
    
    #region Problem 3
    public class StringComparerByLength : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return x.Length.CompareTo(y.Length);
        }
    }
    #endregion
    
    #region Problem 4
    public class Manager : Employee, IComparable<Manager>
    {
        public int CompareTo(Manager other)
        {
            return this.Salary.CompareTo(other.Salary);
        }
    }
    #endregion
    
    #region Problem 5
    public class EmployeeNameComparer
    {
        public static void Sort(Employee[] employees, Func<Employee, Employee, bool> comparer)
        {
            for (int i = 0; i < employees.Length - 1; i++)
            {
                for (int j = i + 1; j < employees.Length; j++)
                {
                    if (comparer(employees[i], employees[j]))
                    {
                        var temp = employees[i];
                        employees[i] = employees[j];
                        employees[j] = temp;
                    }
                }
            }
        }
    }
    #endregion
    
    #region Problem 6
    public class IntegerSorter
    {
        public void Sort(int[] array)
        {
            Array.Sort(array, delegate (int x, int y) { return x.CompareTo(y); });
            Array.Sort(array, (x, y) => x.CompareTo(y));
        }
    }
    #endregion
    
    #region Problem 7
    public class SortingHelper
    {
        public static void Swap<T>(T[] array, int index1, int index2)
        {
            T temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
    #endregion
    
    #region Problem 8
    public class EmployeeComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            int result = x.Salary.CompareTo(y.Salary);
            return result == 0 ? x.Name.CompareTo(y.Name) : result;
        }
    }
    #endregion
    
    #region Problem 9
    public class DefaultHelper
    {
        public static T GetDefault<T>()
        {
            return default(T);
        }
    }
    #endregion
    
    #region Problem 10
    public class SortingAlgorithmWithClone<T> where T : ICloneable
    {
        public void Sort(T[] array)
        {
            Array.Sort(array);
        }
    }
    #endregion
    
    #region Problem 11
    public delegate string StringTransformer(string input);
    
    public class StringProcessor
    {
        public static List<string> TransformList(List<string> inputList, StringTransformer transformer)
        {
            List<string> result = new List<string>();
            foreach (var item in inputList)
            {
                result.Add(transformer(item));
            }
            return result;
        }
    }
    #endregion
    
    #region Problem 12
    public delegate int IntOperation(int a, int b);
    
    public class IntOperationProcessor
    {
        public static int Execute(int a, int b, IntOperation operation)
        {
            return operation(a, b);
        }
    }
    #endregion
    
    #region Problem 13
    public delegate R GenericTransform<T, R>(T input);
    
    public class GenericTransformer
    {
        public static List<R> Transform<T, R>(List<T> inputList, GenericTransform<T, R> transformer)
        {
            List<R> result = new List<R>();
            foreach (var item in inputList)
            {
                result.Add(transformer(item));
            }
            return result;
        }
    }
    #endregion
    
    #region Problem 14
    public class FuncSquare
    {
        public static List<int> ApplySquare(List<int> numbers, Func<int, int> squareFunc)
        {
            List<int> result = new List<int>();
            foreach (var n in numbers)
            {
                result.Add(squareFunc(n));
            }
            return result;
        }
    }
    #endregion
    
    #region Problem 15
    public class StringPrinter
    {
        public static void ApplyAction(List<string> list, Action<string> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
        }
    }
    #endregion
    
    #region Problem 16
    public class PredicateFilter
    {
        public static List<int> FilterEven(List<int> numbers, Predicate<int> predicate)
        {
            return numbers.FindAll(predicate);
        }
    }
    #endregion
    
    #region Problem 17
    public class AnonymousFilter
    {
        public static List<string> Filter(List<string> strings, Func<string, bool> condition)
        {
            return strings.FindAll(new Predicate<string>(condition));
        }
    }
    #endregion
    
    #region Problem 18
    public class AnonymousMathOperation
    {
        public static int Execute(int a, int b, Func<int, int, int> operation)
        {
            return operation(a, b);
        }
    }
    #endregion
    
    #region Problem 19
    public class LambdaStringFilter
    {
        public static List<string> Filter(List<string> strings, Func<string, bool> condition)
        {
            return strings.FindAll(new Predicate<string>(condition));
        }
    }
    #endregion
    
    #region Problem 20
    public class LambdaDoubleMath
    {
        public static double Execute(double a, double b, Func<double, double, double> operation)
        {
            return operation(a, b);
        }
    }
    #endregion


}

