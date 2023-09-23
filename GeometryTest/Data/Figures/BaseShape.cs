using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTest.Models.Figures
{
    abstract public class BaseShape
    {
        public double Perimeter { get; init; }
        public double Area { get; init; }
    }
}
