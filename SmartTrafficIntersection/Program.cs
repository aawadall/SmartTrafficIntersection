using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartTrafficIntersection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Intersection FourWay = new FourDirectionIntersection();
            Simulator sim = new Simulator(5,3,3);
            Console.WriteLine("Initial Queue Wait Time : "+sim.WaitTime);
            for(int tick=0;tick < 10; tick++)
            {
                sim.SimulateTraffic(true,false);
                Console.WriteLine(String.Format("Wait Time @ Tick [{0}] : {1}",tick,sim.WaitTime));
            }
        }
    }
}