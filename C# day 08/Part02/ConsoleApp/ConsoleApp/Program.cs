using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using ConsoleApp.Series;
using ConsoleApp.Utilities;
using System;
using System.Collections.Generic;
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
            Console.WriteLine("    Shape Series Demo");
            Console.WriteLine("Squares:");
            PrintTenShapes(new SquareSeries());
            Console.WriteLine("Circles:");
            PrintTenShapes(new CircleSeries());

            Console.WriteLine("\n    Sorting Shapes by Area");
            Shape[] shapes = {
                new Shape { Name = "Square", Area = 25 },
                new Shape { Name = "Circle", Area = 78.5 },
                new Shape { Name = "Rectangle", Area = 40 }
            };

            Array.Sort(shapes);
            foreach (var s in shapes)
                Console.WriteLine(s);

            Console.WriteLine("\n    Geometric Shapes Demo\n");
            GeometricShape rect = new Rectangle(5, 10);
            GeometricShape tri = new Triangle(6, 8);

            Console.WriteLine($"Rectangle Area: {rect.CalculateArea()}, Perimeter: {rect.Perimeter}");
            Console.WriteLine($"Triangle Area: {tri.CalculateArea()}, Perimeter: {tri.Perimeter}");

            Console.WriteLine("\n    Selection Sort on Shape Areas\n");
            int[] areas = { 25, 78, 40, 12, 55 };
            SortingUtil.SelectionSort(areas);
            Console.WriteLine(string.Join(", ", areas));

            Console.WriteLine("\n    Factory Pattern Demo\n");
            ShapeFactory factory = new ShapeFactory();
            GeometricShape shape1 = factory.CreateShape("rectangle", 4, 6);
            GeometricShape shape2 = factory.CreateShape("triangle", 5, 7);

            Console.WriteLine($"Factory created Rectangle Area: {shape1.CalculateArea()}");
            Console.WriteLine($"Factory created Triangle Area: {shape2.CalculateArea()}");
        }

        static void PrintTenShapes(IShapeSeries series)
        {
            series.ResetSeries();
            for (int i = 0; i < 10; i++)
            {
                series.GetNextArea();
                Console.WriteLine(series.CurrentShapeArea);
            }
        }
    }
}