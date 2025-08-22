using ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Series
{
    internal class CircleSeries : IShapeSeries
    {
        private int radius = 1;
        public int CurrentShapeArea { get; set; }

        public void GetNextArea()
        {
            CurrentShapeArea = (int)(Math.PI * radius * radius);
            radius++;
        }

        public void ResetSeries()
        {
            radius = 1;
            CurrentShapeArea = 0;
        }
    }
}
