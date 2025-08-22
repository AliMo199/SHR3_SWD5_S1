using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    internal class Shape:IComparable<Shape>
    {
        public string Name { get; set; }
        public double Area { get; set; }

        public int CompareTo(Shape other)
        {
            return Area.CompareTo(other.Area);
        }

        public override string ToString()
        {
            return $"{Name} with Area: {Area:F2}";
        }
    }
}
