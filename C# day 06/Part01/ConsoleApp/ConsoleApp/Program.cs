using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Problem1
            //Point p1 = new Point();    
            //Point p2 = new Point(5, 7);
            //Console.WriteLine(p1);
            //Console.WriteLine(p2);
            #endregion
            #region Problem2
            //TypeA obj = new TypeA(10, 20, 30);
            //obj.ShowPrivate();        
            //Console.WriteLine(obj.G); 
            //Console.WriteLine(obj.H);
            #endregion
            #region Problem3
            //Employee emp = new Employee(1, "Omar", 50000);
            //Console.WriteLine($"Name: {emp.GetName()}, Salary: {emp.EmployeeSalary}");
            //emp.SetName("Ali");
            //emp.EmployeeSalary = 60000;
            //Console.WriteLine($"Updated Name: {emp.GetName()}, Salary: {emp.EmployeeSalary}");
            #endregion
            #region Problem4
            //Point p1 = new Point(5);
            //Point p2 = new Point(3, 7);
            //Console.WriteLine(p1);
            //Console.WriteLine(p2);
            #endregion
            #region Problem5
            //Point p1 = new Point(1, 2);
            //Point p2 = new Point(10, 20);
            //Point p3 = new Point(-5, 8);
            //Console.WriteLine(p1);
            //Console.WriteLine(p2);
            //Console.WriteLine(p3);
            #endregion
            #region Problem6
            //static void ModifyPoint(Point p)
            //{
            //    p.X = 100;
            //    p.Y = 200;
            //}

            //static void ModifyEmployee(Employee e)
            //{
            //    e.Name = "Changed";
            //}

            //Point pt = new Point { X = 1, Y = 2 };
            //Employee emp = new Employee { Name = "Alice" };
            //ModifyPoint(pt); // struct passed by value
            //ModifyEmployee(emp); // Class passed by reference
            //Console.WriteLine($"Point after modify: X={pt.X}, Y={pt.Y}"); 
            //Console.WriteLine($"Employee after modify: Name={emp.Name}"); 
            #endregion


            //struct Point
            //{
            //    public int X;
            //    public int Y;
            //    public Point(int unused = 0) : this(0, 0) { }
            //    public Point(int x, int y)
            //    {
            //        X = x;
            //        Y = y;
            //    }
            //    public override string ToString()
            //    {
            //        return $"({X}, {Y})";
            //    }
            //}
            //public class TypeA
            //{
            //    private int F;         
            //    internal int G;        
            //    public int H;          
            //    public TypeA(int f, int g, int h)
            //    {
            //        F = f;
            //        G = g;
            //        H = h;
            //    }
            //    public void ShowPrivate()
            //    {
            //        Console.WriteLine($"Private F: {F}");
            //    }
            //}

            //struct Employee
            //{
            //    private int EmpId;
            //    private string Name;
            //    private double Salary;
            //    public Employee(int id, string name, double salary)
            //    {
            //        EmpId = id;
            //        Name = name;
            //        Salary = salary;
            //    }
            //    public string GetName() => Name;
            //    public void SetName(string name) => Name = name;
            //    public double EmployeeSalary
            //    {
            //        get => Salary;
            //        set => Salary = value;
            //    }
            //}

            //struct Point
            //{
            //    public int X;
            //    public int Y;

            //    public Point(int x)
            //    {
            //        X = x;
            //        Y = 0;
            //    }

            //    public Point(int x, int y) 
            //    {
            //        X = x;
            //        Y = y;
            //    }

            //    public override string ToString() => $"({X}, {Y})";
            //}

            //struct Point
            //{
            //    public int X;
            //    public int Y;

            //    public Point(int x, int y)
            //    {
            //        X = x;
            //        Y = y;
            //    }

            //    public override string ToString()
            //    {
            //        return $"Point Coordinates => X: {X}, Y: {Y}";
            //    }
            //}

            //struct Point
            //{
            //    public int X;
            //    public int Y;
            //}

            //class Employee
            //{
            //    public string Name;
            //}
        }
    }
}