using System;
using System.Collections.Generic;

namespace SmartTrafficIntersection
{
    // Intersection Superclass
    public class Intersection : IIntersection
	{
		// An Intersection should have a set of lanes with different directions, and a set of traffic lights controlling them
		protected List<Direction> _directions;
		protected List<TrafficController> _trafficControllers;
        protected List<Lane> _lanes;

        public int Directons {get{return _directions.Count;}} 
        public int Lanes  {get{return _lanes.Count;}}
        public void Simulate()
        {
            for(int i=0;i< _lanes.Count && _lanes.Count > 0;i++)
                for(int j=0;j<_trafficControllers.Count && _trafficControllers.Count>0;j++)
                    _lanes[i].Simulate(_trafficControllers[j]);
        }
        public virtual int TotalWaitTime()
        {
            int WaitTime = 0;
            for(int i=0;i< _lanes.Count && _lanes.Count > 0;i++)
            {
                Console.WriteLine(String.Format("Intersection > WT:{0}",_lanes[i].WaitTime));
                WaitTime+= _lanes[i].WaitTime;
            }
            Console.WriteLine(String.Format("Wait Time: {0}",WaitTime));
            return WaitTime;
        }
        public virtual void Control(int controlSignal)
        {
            Console.WriteLine(String.Format("Control Signal : {0}",Convert.ToString(controlSignal,2)));
            // rightmost bit is bit 0
            for(int j=0;j<_trafficControllers.Count && _trafficControllers.Count>0;j++)
            {
                _trafficControllers[j].Allowed = (controlSignal & 1) == 1;
                controlSignal = controlSignal >> 1;
            } 
        } // Control Signal is a bitmap
        public  int State(){
           // rightmost bit is bit 0
           int State = 0;
           for(int j=0;j<_trafficControllers.Count && _trafficControllers.Count>0;j++)
           {
           if( _trafficControllers[j].Allowed)
                State |= 1;
            State = State << 1;
           }
           return State; 
        } // Current State of the Intersection in terms of Traffic Controllers 

    }
}
