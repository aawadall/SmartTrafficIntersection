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
        protected int tick;

        public int Directons 
		{
			get
			{
				return _directions.Count;
			}
		} 
        public int Lanes  
		{
			get
			{
				return _lanes.Count;
			}
		}
        public void Simulate()
        {
            tick += tick < 15?1:-15;
            
            for(int i=0;i< _lanes.Count && _lanes.Count > 0;i++)
	    {
                for(int j=0;j<_trafficControllers.Count && _trafficControllers.Count>0;j++)
		{
                    _lanes[i].Simulate(_trafficControllers[j]);
		}
	     }
        }
        public virtual int TotalWaitTime()
        {
            int WaitTime = 0;
            for(int i=0;i< _lanes.Count && _lanes.Count > 0;i++)
            {
                WaitTime+= _lanes[i].WaitTime;
            }
            return _lanes.Count==0?0:(int)( (double)WaitTime/_lanes.Count);
        }
        public virtual void Control(int controlSignal)
        {
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
                {
                    //Console.WriteLine("Allowed");
                    State += 2^j;
                }
            //State = State << 1;
            //Console.WriteLine(String.Format("State Build : {0}",
            //State));
           }
           State = (State << 4) + tick;
           return State; 
        } // Current State of the Intersection in terms of Traffic Controllers 

        public virtual void AlterFlow(int laneIndex, int inFlowDelta, int outFlowDelta)
        {
            if(laneIndex < _lanes.Count)
            {
                _lanes[laneIndex].InFlow += inFlowDelta;
                if (_lanes[laneIndex].InFlow < 0 )
		{
                    _lanes[laneIndex].InFlow = 0;
		}    
                _lanes[laneIndex].OutFlow += outFlowDelta;
                if (_lanes[laneIndex].OutFlow < 0 )
		{
                    _lanes[laneIndex].OutFlow = 0;  
		}
            }
        } // Alter flow of a lane if exist
    }
}
