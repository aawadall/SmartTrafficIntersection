using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartTrafficIntersection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Intersection FourWay = new FourDirectionIntersection();
            Console.WriteLine(FourWay.Directions);
        }
    }
}