using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartTrafficIntersection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Random rnd = new Random();
            Intersection intersection = new FourDirectionIntersection();
            Console.WriteLine(String.Format("Initial Wait Time: {0}",intersection.TotalWaitTime()));
            for(int tick=0;tick < 16; tick++)
            {
                intersection.AlterFlow(rnd.Next(4),rnd.Next(-10,10),rnd.Next(-10,10));
                intersection.Control(rnd.Next(0x8));
                intersection.Simulate();
                Console.WriteLine(String.Format("[{0}] : WT : {1} : State {2}",
                tick,
                intersection.TotalWaitTime(),
                Convert.ToString(intersection.State(),2)));
            }
        }
    }
}