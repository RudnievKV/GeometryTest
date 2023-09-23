using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTest.Models.Figures
{
    public class Circle : BaseShape
    {
        public double Radius { get; init; }
        public Circle() { }
        public Circle(double radius)
        {
            Radius = radius;
            Area = radius * radius * Math.PI;
            Perimeter = 2 * radius * Math.PI;
        }

    }
}
