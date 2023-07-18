using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Generic
    {
        // Anytime I need wanna use methods that only differs from data-type in arguments or return-type - generics could be a good solution
        // Generics are placeholder for datatypes

        public void GetSum<T>(T num1, T num2)
        {
            double x1 = Convert.ToDouble(num1);
            double x2 = Convert.ToDouble(num2);

            Console.WriteLine($"{x1} + {x2} = {x1 + x2}");

        }

        public struct Rectangle<T>
        {
            public T width { get; set; }
            public T length { get; set; }

            public Rectangle(T w, T l)
            {
                width = w;
                length = l;
            }

            public string GetArea()
            {
                double dblW = Convert.ToDouble(width);
                double dblL = Convert.ToDouble(length);

                return string.Format($"{width} * {length} = {dblW * dblL}");
            }
        }
    }

}
