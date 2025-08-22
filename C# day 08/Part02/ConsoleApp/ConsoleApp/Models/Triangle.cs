using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    internal class Triangle : GeometricShape
    {
        public Triangle(double dim1, double dim2) : base(dim1, dim2) { }

        public override double CalculateArea()
        {
            return 0.5 * Dimension1 * Dimension2;
        }

        public override double Perimeter
        {
            get { return Dimension1 + Dimension2 + System.Math.Sqrt(Dimension1 * Dimension1 + Dimension2 * Dimension2); }
        }
    }
}
