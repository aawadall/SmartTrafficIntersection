using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartTrafficIntersection
{
    // Simulates Traffic 
    public class Simulator
    {
        private const int _tick=1;
        private const double _riskFactor=0.7;
        
        protected Queue<int> _waitTime;
        protected static Random _rnd = new Random();
        protected int _inFlow;
        protected int _outFlow;
        // Constructors
        public Simulator(int initialLength,int inFlow, int outFlow)
        {
            _inFlow = inFlow;
            _outFlow = outFlow;

            _waitTime = new Queue<int>();
            for(int i=0;i<initialLength;i++)
            {
                _waitTime.Enqueue(0);
            }
        }

        public Simulator(int inFlow, int outFlow) : this(0,inFlow,outFlow)
        {}

        // Simulation
        public void Wait() // Add one tick to each waiting car
        {
            for(int i=0;i<_waitTime.Count;i++)
            {
                _waitTime.Enqueue(_waitTime.Dequeue()+_tick);
            }
        }

        // Measure 
        public int WaitTime
        {
            get{
                int Wait=0;
                if(_waitTime.Count > 0)
                {
                    for(int i=0;i<_waitTime.Count;i++)
                        Wait += _waitTime.ElementAt(i);   
                }
                return _waitTime.Count==0?0: (int)( (double)Wait/(double) _waitTime.Count);
            }
        }

        public void SimulateTraffic(bool WayOut, bool RiskyTraffic)
        {
            Wait();
            // If there is no way Out, accumilate traffic, otherwise have ins and outs
            if(WayOut)
            {
                int TrafficOut = _outFlow;
                if(RiskyTraffic)
                {   // Multiply Flow by factor 
                    TrafficOut = (int) (TrafficOut * _riskFactor);
                }
                TrafficOut = _rnd.Next(TrafficOut);
                  
                for(int i=0;i<TrafficOut && _waitTime.Count >0;i++)
                {
                    _waitTime.Dequeue();
                }
                
            }

            int TrafficIn = _rnd.Next(_inFlow);
            
            for(int i=0;i<TrafficIn;i++)
            {
                _waitTime.Enqueue(0);
            }
        }
    }
}