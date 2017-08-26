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
            //Simulator sim = new Simulator(5,3,3);
            Direction dir0 = new Direction("Main Direction");
            Direction dir1 = new Direction("Secondary Direction");
            Direction dir2 = new Direction("Not Allowed Direction");

            TrafficController controller = new TrafficController("Controller",dir0,dir1);

            Lane lane0 = new Lane("Lane 0",dir0,5,15,15);
            Lane lane1 = new Lane("Lane 1",dir1,5,15,15);
            Lane lane2 = new Lane("Lane 2",dir2,5,15,15); 
            Console.WriteLine("Initial Queue Wait Time : "+lane0.WaitTime);
            for(int tick=0;tick < 16; tick++)
            {
                if (tick%3 == 0)
                    controller.Flip();
                lane0.Simulate(controller);
                lane1.Simulate(controller);
                lane2.Simulate(controller);
                Console.WriteLine(String.Format("Tick [{0}] - Controller is {1}",
                tick,
                controller.Status()));

                Console.WriteLine(String.Format("Prim. Lane [{0}\t] Sec. Lane [{1}\t] Opp. Lane [{2}\t]",
                lane0.WaitTime,
                lane1.WaitTime,
                lane2.WaitTime));
            }
        }
    }
}