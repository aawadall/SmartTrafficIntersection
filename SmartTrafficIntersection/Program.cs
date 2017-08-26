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

            Lane lane0 = new Lane("Lane 0",dir0,5,5,5);
            Lane lane1 = new Lane("Lane 1",dir1,5,5,5);
            Lane lane2 = new Lane("Lane 2",dir2,5,5,5); 
            Console.WriteLine("Initial Queue Wait Time : "+lane0.WaitTime);
            for(int tick=0;tick < 10; tick++)
            {
                if (tick%3 == 0)
                    controller.Flip();
                lane0.Simulate(controller);
                Console.WriteLine(String.Format("Wait Time @ Tick [{0}] - Controller is {2}: {1}",
                tick,
                lane0.WaitTime,
                controller.Status()));
            }
        }
    }
}