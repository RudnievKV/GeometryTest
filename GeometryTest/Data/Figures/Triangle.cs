using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTest.Models.Figures
{
    public class Triangle : BaseShape
    {
        public double FirstSide { get; init; }
        public double SecondSide { get; init; }
        public double ThirdSide { get; init; }
        public Triangle() { }
        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
            Perimeter = firstSide + secondSide + thirdSide;
            Area = firstSide * secondSide * Math.Sin(thirdSide) / 2;
        }
    }
}
