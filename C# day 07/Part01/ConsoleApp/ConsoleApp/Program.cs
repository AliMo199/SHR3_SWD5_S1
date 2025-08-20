using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
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
            //Car c1 = new Car();
            //Car c2 = new Car(101);
            //Car c3 = new Car(102, "Toyota");
            //Car c4 = new Car(103, "BMW", 45000);

            //Console.WriteLine(c1);
            //Console.WriteLine(c2);
            //Console.WriteLine(c3);
            //Console.WriteLine(c4);
            #endregion
            #region Problem2
            //Calculator calc = new Calculator();

            //Console.WriteLine("Sum of 2 integers: " + calc.Sum(5, 10));
            //Console.WriteLine("Sum of 3 integers: " + calc.Sum(2, 4, 6));
            //Console.WriteLine("Sum of 2 doubles: " + calc.Sum(2.5, 3.7));
            #endregion
            #region Problem3
            //Child obj = new Child(3, 4, 5);
            //Console.WriteLine($"X={obj.X}, Y={obj.Y}, Z={obj.Z}");
            #endregion
            #region Problem4
            //Parent p = new Parent(2, 3);
            //Child c = new Child(2, 3, 4);

            //Console.WriteLine("Parent Product: " + p.Product());
            //Console.WriteLine("Child Product (override): " + c.Product());

            //Parent refToChild = new Child(2, 3, 4);
            //Console.WriteLine("Ref to Child Product (polymorphism): " + refToChild.Product());
            #endregion
            #region Problem5
            //Parent p = new Parent(1, 2);
            //Child c = new Child(3, 4, 5);

            //Console.WriteLine(p);
            //Console.WriteLine(c);

            //Parent refToChild = new Child(7, 8, 9);
            //Console.WriteLine(refToChild);
            #endregion
            #region Problem6
            //Shape rect = new Rectangle(5, 10);

            //rect.Draw();
            //Console.WriteLine("Area = " + rect.CalculateArea());
            #endregion
        }


        #region Problem 1 classes
        //class Car
        //{
        //    public int Id { get; set; }
        //    public string Brand { get; set; }
        //    public double Price { get; set; }

        //    public Car()
        //    {
        //        Id = 0;
        //        Brand = "Unknown";
        //        Price = 0.0;
        //    }

        //    public Car(int id)
        //    {
        //        Id = id;
        //        Brand = "Unknown";
        //        Price = 0.0;
        //    }

        //    public Car(int id, string brand)
        //    {
        //        Id = id;
        //        Brand = brand;
        //        Price = 0.0;
        //    }

        //    public Car(int id, string brand, double price)
        //    {
        //        Id = id;
        //        Brand = brand;
        //        Price = price;
        //    }

        //    public override string ToString() => $"Car [Id={Id}, Brand={Brand}, Price={Price}]";
        //} 
        #endregion

        #region Problem 2 classes
        //class Calculator
        //{
        //    public int Sum(int a, int b) => a + b;
        //    public int Sum(int a, int b, int c) => a + b + c;
        //    public double Sum(double a, double b) => a + b;
        //} 
        #endregion

        #region Problem 3 classes
        //class Parent
        //{
        //    public int X { get; set; }
        //    public int Y { get; set; }

        //    public Parent(int x, int y)
        //    {
        //        X = x;
        //        Y = y;
        //    }
        //}

        //class Child : Parent
        //{
        //    public int Z { get; set; }

        //    public Child(int x, int y, int z) : base(x, y)
        //    {
        //        Z = z;
        //    }
        //} 
        #endregion

        #region Problem 4 classes
        //class Parent
        //{
        //    public int X { get; set; }
        //    public int Y { get; set; }

        //    public Parent(int x, int y)
        //    {
        //        X = x;
        //        Y = y;
        //    }

        //    public virtual int Product() => X * Y;
        //}

        //class Child : Parent
        //{
        //    public int Z { get; set; }

        //    public Child(int x, int y, int z) : base(x, y)
        //    {
        //        Z = z;
        //    }

        //    //public new int Product() => X * Y * Z;

        //    public override int Product() => (X + Y) * Z;
        //} 
        #endregion

        #region Problem 5 classes
        //class Parent
        //{
        //    public int X { get; set; }
        //    public int Y { get; set; }

        //    public Parent(int x, int y)
        //    {
        //        X = x;
        //        Y = y;
        //    }

        //    public override string ToString() => $"Parent (X={X}, Y={Y})";
        //}

        //class Child : Parent
        //{
        //    public int Z { get; set; }

        //    public Child(int x, int y, int z) : base(x, y)
        //    {
        //        Z = z;
        //    }

        //    public override string ToString() => $"Child (X={X}, Y={Y}, Z={Z})";
        //} 
        #endregion

        #region Problem 6 classes
        //abstract class Shape
        //{
        //    public virtual void Draw() => Console.WriteLine("Drawing Shape");
        //    public abstract double CalculateArea();
        //}

        //class Rectangle : Shape
        //{
        //    public double Width { get; set; }
        //    public double Height { get; set; }

        //    public Rectangle(double width, double height)
        //    {
        //        Width = width;
        //        Height = height;
        //    }

        //    public override void Draw() => Console.WriteLine("Drawing Rectangle");
        //    public override double CalculateArea() => Width * Height;
        //} 
        #endregion
    }
}