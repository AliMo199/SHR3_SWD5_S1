using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Utilities
{
    internal class ShapeFactory
    {
        public GeometricShape CreateShape(string shapeType, double dim1, double dim2)
        {
            switch (shapeType.ToLower())
            {
                case "rectangle":
                    return new Rectangle(dim1, dim2);

                case "triangle":
                    return new Triangle(dim1, dim2);

                default:
                    throw new ArgumentException("Invalid shape type!");
            }
        }
    }
}
