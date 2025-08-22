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
            //IVehicle car = new Car();
            //IVehicle bike = new Bike();

            //car.StartEngine();
            //car.StopEngine();

            //bike.StartEngine();
            //bike.StopEngine();
            #endregion
            #region Problem2
            //Shape rect = new Rectangle(5, 10);
            //Shape circle = new Circle(7);

            //rect.Display();
            //Console.WriteLine("Rectangle area: " + rect.GetArea());

            //circle.Display();
            //Console.WriteLine("Circle area: " + circle.GetArea());
            #endregion
            #region Problem3
            //    Product[] products =
            //{
            //    new Product { Id = 1, Name = "Laptop", Price = 900 },
            //    new Product { Id = 2, Name = "Phone", Price = 600 },
            //    new Product { Id = 3, Name = "Tablet", Price = 300 }
            //};

            //    Array.Sort(products);

            //    foreach (var p in products)
            //        Console.WriteLine($"{p.Name} - ${p.Price}");
            #endregion
            #region Problem4
            //Student s1 = new Student(1, "Alice", "A");
            //Student s2 = s1;
            //s2.Name = "Changed Shallow";
            //Console.WriteLine($"Shallow Copy -> s1.Name: {s1.Name}, s2.Name: {s2.Name}");
            //Student s3 = new Student(s1);
            //s3.Name = "Changed Deep";
            //Console.WriteLine($"Deep Copy -> s1.Name: {s1.Name}, s3.Name: {s3.Name}");
            #endregion
            #region Problem5
            //Robot robot = new Robot();
            //robot.Walk();
            //IWalkable walkable = robot;
            //walkable.Walk();
            #endregion
            #region Problem6
            //Account acc = new Account();
            //acc.AccountId = 101;
            //acc.AccountHolder = "Ali";
            //acc.Balance = 5000;
            //Console.WriteLine($"{acc.AccountId} - {acc.AccountHolder} - ${acc.Balance}");
            #endregion
            #region Problem7
            //ILogger logger1 = new ConsoleLogger();
            //logger1.Log("Hello World");
            //ILogger logger2 = new ILogger();
            #endregion
            #region Problem8
            //Book b1 = new Book();
            //Book b2 = new Book("C# Programming");
            //Book b3 = new Book("C# Programming", "Alawy");
            //Console.WriteLine($"{b1.Title}, {b1.Author}");
            //Console.WriteLine($"{b2.Title}, {b2.Author}");
            //Console.WriteLine($"{b3.Title}, {b3.Author}");
            #endregion
        }


        #region Problem 1 classes
        //interface IVehicle
        //{
        //    void StartEngine();
        //    void StopEngine();
        //}

        //class Car : IVehicle
        //{
        //    public void StartEngine() => Console.WriteLine("Car engine started.");
        //    public void StopEngine() => Console.WriteLine("Car engine stopped.");
        //}

        //class Bike : IVehicle
        //{
        //    public void StartEngine() => Console.WriteLine("Bike engine started.");
        //    public void StopEngine() => Console.WriteLine("Bike engine stopped.");
        //}
        #endregion

        #region Problem 2 classes
        //abstract class Shape
        //{
        //    public abstract double GetArea();

        //    public void Display()
        //    {
        //        Console.WriteLine("This is a shape.");
        //    }
        //}

        //class Rectangle : Shape
        //{
        //    public double Width { get; set; }
        //    public double Height { get; set; }

        //    public Rectangle(double w, double h) => (Width, Height) = (w, h);

        //    public override double GetArea() => Width * Height;
        //}

        //class Circle : Shape
        //{
        //    public double Radius { get; set; }

        //    public Circle(double r) => Radius = r;

        //    public override double GetArea() => Math.PI * Radius * Radius;
        //}
        #endregion

        #region Problem 3 classes
        //class Product : IComparable<Product>
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //    public double Price { get; set; }

        //    public int CompareTo(Product other)
        //    {
        //        return this.Price.CompareTo(other.Price);
        //    }
        //}
        #endregion

        #region Problem 4 classes
        //class Student
        //{
        //    public int Id;
        //    public string Name;
        //    public string Grade;

        //    // Copy Constructor (Deep Copy)
        //    public Student(Student other)
        //    {
        //        Id = other.Id;
        //        Name = string.Copy(other.Name);
        //        Grade = string.Copy(other.Grade);
        //    }

        //    public Student(int id, string name, string grade)
        //    {
        //        Id = id; Name = name; Grade = grade;
        //    }
        //}
        #endregion

        #region Problem 5 classes
        //interface IWalkable
        //{
        //    void Walk();
        //}

        //class Robot : IWalkable
        //{
        //    // Class method
        //    public void Walk()
        //    {
        //        Console.WriteLine("Robot is walking using class method.");
        //    }

        //    // Explicit interface method
        //    void IWalkable.Walk()
        //    {
        //        Console.WriteLine("Robot is walking (IWalkable interface).");
        //    }
        //}
        #endregion

        #region Problem 6 classes
        //struct Account
        //{
        //    private int accountId;
        //    private string accountHolder;
        //    private double balance;

        //    public int AccountId { get => accountId; set => accountId = value; }
        //    public string AccountHolder { get => accountHolder; set => accountHolder = value; }
        //    public double Balance { get => balance; set => balance = value; }
        //}
        #endregion

        #region Problem 7 classes
        //interface ILogger
        //{
        //    void Log(string message)
        //    {
        //        Console.WriteLine("Default Log: " + message);
        //    }
        //}

        //class ConsoleLogger : ILogger
        //{
        //    public void Log(string message)
        //    {
        //        Console.WriteLine("Console Logger: " + message);
        //    }
        //}
        #endregion

        #region Problem 8 classes
        //class Book
        //{
        //    public string Title { get; set; }
        //    public string Author { get; set; }

        //    public Book()
        //    {
        //        Title = "Unknown";
        //        Author = "Unknown";
        //    }

        //    public Book(string title)
        //    {
        //        Title = title;
        //        Author = "Unknown";
        //    }

        //    public Book(string title, string author)
        //    {
        //        Title = title;
        //        Author = author;
        //    }
        //}
        #endregion
    }
}