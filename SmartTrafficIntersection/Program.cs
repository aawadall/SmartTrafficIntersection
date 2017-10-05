using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartTrafficIntersection
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            int lifeTime = 40960;
            Random rnd = new Random();
            Smart4WayIntersection intersection = new Smart4WayIntersection();
            int[] WaitTime = new int[lifeTime]; 
            Console.WriteLine(String.Format("Initial Wait Time: {0}",intersection.TotalWaitTime()));
            for(int tick=0;tick < lifeTime; tick++)
            {
                intersection.Control();
                intersection.Simulate();
                Console.WriteLine(String.Format("[{0}] : WT : {1} : State {2}",
                tick,
                intersection.TotalWaitTime(),
                Convert.ToString(intersection.State(),16)));
            }
            Console.WriteLine("Wait Time Progress");
            intersection.Report();
        }
    }
}
