using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTest.Models.Figures
{
    public class Rectangle : BaseShape
    {
        public double Width { get; init; }
        public double Height { get; init; }
        public Rectangle() { }
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
            Perimeter = (width + height) * 2;
            Area = width * height;
        }

    }
}
