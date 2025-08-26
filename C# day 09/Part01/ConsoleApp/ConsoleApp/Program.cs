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
        //Child obj = new Child();
        //obj.DisplaySalary();
        #endregion

        #region Problem 2
        //Console.WriteLine("Perimeter: " + Utility.PerimeterOfRectangle(10, 5));
        //Console.WriteLine("100C = " + Utility.ToFahrenheit(100) + "F");
        //Console.WriteLine("212F = " + Utility.ToCelsius(212) + "C");
        #endregion

        #region Problem 3
        //ComplexNumber c1 = new ComplexNumber(2, 3);
        //ComplexNumber c2 = new ComplexNumber(1, 4);
        //Console.WriteLine("Multiplication: " + (c1 * c2));
        #endregion

        #region Problem 4
        //Console.WriteLine($"Default int enum size: {sizeof(int)} bytes");
        //Console.WriteLine($"Byte enum size: {sizeof(Gender)} byte");
        #endregion

        #region Problem 5
        //string input = "B";
        //if (Enum.TryParse(input, out Grades grade))
        //    Console.WriteLine($"Parsed grade: {grade}");
        //else
        //    Console.WriteLine("Invalid grade input.");
        #endregion

        #region Problem 6
        //Employee[] employees = {
        //    new Employee { Id = 1, Name = "Alice" },
        //    new Employee { Id = 2, Name = "Bob" }
        //};
        //Employee search = new Employee { Id = 2, Name = "Bob" };
        //int index = Helper2<Employee>.SearchArray(employees, search);
        //Console.WriteLine("Employee found at index: " + index);

        //int[] nums = { 1, 2, 3, 2, 4 };
        //Helper2<int>.ReplaceArray(nums, 2, 9);
        //Console.WriteLine("Ints: " + string.Join(", ", nums));
        #endregion

        #region Problem 7
        //Console.WriteLine("Max int: " + Helper.Max(5, 10));
        //Console.WriteLine("Max double: " + Helper.Max(7.5, 3.2));
        //Console.WriteLine("Max string: " + Helper.Max("Apple", "Banana"));
        #endregion

        #region Problem 8
        //Rectangle a = new Rectangle { Length = 5, Width = 10 };
        //Rectangle b = new Rectangle { Length = 7, Width = 14 };
        //Swap(ref a, ref b);
        //Console.WriteLine($"Rect A: {a.Length}x{a.Width}");
        //Console.WriteLine($"Rect B: {b.Length}x{b.Width}");
        #endregion

        #region Problem 9
        //Department hr = new Department { Name = "HR" };
        //Department it = new Department { Name = "IT" };
        //Employee[] emps = {
        //    new Employee { Name = "Ali", Dept = hr },
        //    new Employee { Name = "Bassem", Dept = it }
        //};
        //Employee searchDept = new Employee { Dept = it };
        //int idx = Helper2<Employee>.SearchArray(emps, searchDept);
        //Console.WriteLine("Employee in IT found at index: " + idx);
        #endregion

        #region Problem 10
        //CircleStruct cs1 = new CircleStruct { Radius = 5, Color = "Red" };
        //CircleStruct cs2 = new CircleStruct { Radius = 5, Color = "Red" };
        //Console.WriteLine("Struct == : " + (cs1 == cs2));
        //Console.WriteLine("Struct Equals: " + cs1.Equals(cs2));

        //CircleClass cc1 = new CircleClass { Radius = 5, Color = "Red" };
        //CircleClass cc2 = new CircleClass { Radius = 5, Color = "Red" };
        //Console.WriteLine("Class == : " + (cc1 == cc2));
        //Console.WriteLine("Class Equals: " + cc1.Equals(cc2));
        #endregion

        #region Problem 11
        //Department2 hr = new Department2 { Name = "HR" };
        //Department2 it = new Department2 { Name = "IT" };
        //EmployeeWithDept[] staff = {
        //    new EmployeeWithDept { Name = "Ali", Dept = hr },
        //    new EmployeeWithDept { Name = "Bassem", Dept = it }
        //};
        //EmployeeWithDept searchByDept = new EmployeeWithDept { Dept = it };
        //int found = Helper2<EmployeeWithDept>.SearchArray(staff, searchByDept);
        //Console.WriteLine("Employee in IT found at index: " + found);
        #endregion

        #region Problem 12
        //CircleVal cv1 = new CircleVal { Radius = 5, Color = "Red" };
        //CircleVal cv2 = new CircleVal { Radius = 5, Color = "Red" };
        //Console.WriteLine("Struct == : " + (cv1 == cv2));
        //Console.WriteLine("Struct Equals: " + cv1.Equals(cv2));

        //CircleRef cr1 = new CircleRef { Radius = 5, Color = "Red" };
        //CircleRef cr2 = new CircleRef { Radius = 5, Color = "Red" };
        //Console.WriteLine("Class == : " + (cr1 == cr2));
        //Console.WriteLine("Class Equals: " + cr1.Equals(cr2));
        #endregion

        //static void Swap(ref Rectangle r1, ref Rectangle r2)
        //{
        //    Rectangle temp = r1;
        //    r1 = r2;
        //    r2 = temp;
        //}
    }


    #region Problem 1 classes
    //class Parent
    //{
    //    public virtual decimal Salary { get; set; } = 5000;
    //}

    //class Child : Parent
    //{
    //    public sealed override decimal Salary { get; set; } = 7000;

    //    public void DisplaySalary()
    //    {
    //        Console.WriteLine($"Salary is: {Salary}");
    //    }
    //}
    #endregion

    #region Problem 2 classes
    //static class Utility
    //{
    //    public static double PerimeterOfRectangle(double length, double width)
    //    {
    //        return 2 * (length + width);
    //    }

    //    public static double ToFahrenheit(double c) => (c * 9 / 5) + 32;
    //    public static double ToCelsius(double f) => (f - 32) * 5 / 9;
    //}
    #endregion

    #region Problem 3 classes
    //class ComplexNumber
    //{
    //    public double Real { get; set; }
    //    public double Imag { get; set; }

    //    public ComplexNumber(double r, double i)
    //    {
    //        Real = r; Imag = i;
    //    }

    //    public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
    //    {
    //        return new ComplexNumber(
    //            a.Real * b.Real - a.Imag * b.Imag,
    //            a.Real * b.Imag + a.Imag * b.Real
    //        );
    //    }

    //    public override string ToString() => $"{Real} + {Imag}i";
    //}
    #endregion

    #region Problem 4 classes
    //enum Gender : byte { Male, Female, Other }
    #endregion

    #region Problem 5 classes
    //enum Grades { A, B, C, D, F }
    #endregion

    #region Problem 6 classes
    //class Employee
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public Department Dept { get; set; }

    //    public override bool Equals(object obj)
    //    {
    //        if (obj is Employee other)
    //            return Id == other.Id && Name == other.Name;
    //        return false;
    //    }

    //    public override int GetHashCode() => (Id, Name).GetHashCode();
    //}

    //class Helper2<T>
    //{
    //    public static int SearchArray(T[] arr, T item)
    //    {
    //        for (int i = 0; i < arr.Length; i++)
    //            if (arr[i].Equals(item)) return i;
    //        return -1;
    //    }

    //    public static void ReplaceArray(T[] arr, T oldValue, T newValue)
    //    {
    //        for (int i = 0; i < arr.Length; i++)
    //            if (arr[i].Equals(oldValue))
    //                arr[i] = newValue;
    //    }
    //}
    #endregion

    #region Problem 7 classes
    //class Helper
    //{
    //    public static T Max<T>(T a, T b) where T : IComparable<T>
    //    {
    //        return a.CompareTo(b) >= 0 ? a : b;
    //    }
    //}
    #endregion

    #region Problem 8 classes
    //struct Rectangle
    //{
    //    public double Length { get; set; }
    //    public double Width { get; set; }
    //}
    #endregion

    #region Problem 9 classes
    //class Department
    //{
    //    public string Name { get; set; }
    //}
    #endregion

    #region Problem 10 classes
    //struct CircleStruct
    //{
    //    public int Radius { get; set; }
    //    public string Color { get; set; }

    //    public override bool Equals(object obj)
    //    {
    //        if (obj is CircleStruct other)
    //            return Radius == other.Radius && Color == other.Color;
    //        return false;
    //    }

    //    public override int GetHashCode() => (Radius, Color).GetHashCode();

    //    public static bool operator ==(CircleStruct a, CircleStruct b) => a.Equals(b);
    //    public static bool operator !=(CircleStruct a, CircleStruct b) => !a.Equals(b);
    //}

    //class CircleClass
    //{
    //    public int Radius { get; set; }
    //    public string Color { get; set; }
    //}
    #endregion

    #region Problem 11 classes
    //class Department2
    //{
    //    public string Name { get; set; }
    //}

    //class EmployeeWithDept
    //{
    //    public string Name { get; set; }
    //    public Department2 Dept { get; set; }

    //    public override bool Equals(object obj)
    //    {
    //        if (obj is EmployeeWithDept other)
    //            return Dept.Name == other.Dept.Name;
    //        return false;
    //    }

    //    public override int GetHashCode() => Dept.Name.GetHashCode();
    //}
    #endregion

    #region Problem 12 classes
    //struct CircleVal
    //{
    //    public int Radius { get; set; }
    //    public string Color { get; set; }

    //    public override bool Equals(object obj)
    //    {
    //        if (obj is CircleVal other)
    //            return Radius == other.Radius && Color == other.Color;
    //        return false;
    //    }

    //    public override int GetHashCode() => (Radius, Color).GetHashCode();

    //    public static bool operator ==(CircleVal a, CircleVal b) => a.Equals(b);
    //    public static bool operator !=(CircleVal a, CircleVal b) => !a.Equals(b);
    //}

    //class CircleRef
    //{
    //    public int Radius { get; set; }
    //    public string Color { get; set; }
    //}
    #endregion

}

