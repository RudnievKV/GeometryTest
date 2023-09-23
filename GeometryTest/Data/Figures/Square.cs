using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTest.Models.Figures
{
    public class Square : BaseShape
    {
        public double Side { get; init; }
        public Square() { }
        public Square(double side)
        {
            Side = side;
            Perimeter = side * 4;
            Area = side * 4;
        }

    }

}
