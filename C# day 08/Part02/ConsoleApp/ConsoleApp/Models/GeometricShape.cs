using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public abstract class GeometricShape
    {
        public double Dimension1 { get; set; }
        public double Dimension2 { get; set; }

        protected GeometricShape(double dim1, double dim2)
        {
            Dimension1 = dim1;
            Dimension2 = dim2;
        }

        public abstract double CalculateArea();
        public abstract double Perimeter { get; }
    }
}
