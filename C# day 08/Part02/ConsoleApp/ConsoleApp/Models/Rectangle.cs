using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    internal class Rectangle : GeometricShape
    {
        public Rectangle(double dim1, double dim2) : base(dim1, dim2) { }

        public override double CalculateArea()
        {
            return Dimension1 * Dimension2;
        }

        public override double Perimeter
        {
            get { return 2 * (Dimension1 + Dimension2); }
        }
    }
}
