using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartTrafficIntersection
{
    public static class Program
    {
        private static bool _debug; // Code Quality claims it will be initialized with false
        private static bool _report = true; 
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
                if (Program._debug)
                {
                    Console.WriteLine(String.Format("[{0}] : WT : {1} : State {2}",
                    tick,
                    intersection.TotalWaitTime(),
                    Convert.ToString(intersection.State(),16)));
                }
            }
            if (Program._report)
            {
                Console.WriteLine("Wait Time Progress");
                intersection.Report();
            }
        }
    }
}
