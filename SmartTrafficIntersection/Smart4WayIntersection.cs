using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartTrafficIntersection
{
    // Smart 4 Directions Intersection (N, W, S, E)
    public class Smart4WayIntersection : FourDirectionIntersection 
    {
        protected Agent _agent;

        public Smart4WayIntersection():base()
        {
            int states = 16*4; //  16 ticks * 4 modes
            int actions = 4; // 4 modes 
            _agent = new Agent(states, actions);
        }

        protected int MapState(int state)
        {
            //Console.WriteLine(String.Format("Inside Map State {0}",state));
            return state;
            int tick = state & 0xf; 
            state = state >> 4;
            int accum = 0;
            for(int i=0;i<4;i++)
            {
                if((state & 1) == 1)
                    accum += 2^i;
                 state = state >> 1;
            }
            
            /* 
            Console.WriteLine(String.Format("Translating State : {0}\t, from Accum:{1} \t& tick:{2} \t-> {3}",
            state,
            accum,
            tick,
            tick + (accum << 4)));
             */
            //return tick + (accum << 4);
        } // Maps a state from a long format to a numeric format

        protected int MapAction(int action)
        {
            return 1 << action;
        } // Maps a numeric action into bitmap action 
        public  void Control()
        {
            // Using State and Agent, find Control Signal
            int state1 = MapState(State());
            int action = _agent.GetBestMove(state1);
            base.Control(MapAction(action));
            int reward =  -TotalWaitTime();
            int state2 = MapState(State());
            _agent.Learn(state1, state2, action, reward);
        } // Control Signal is a bitmap

        public void Report()
        {
            _agent.Report();
        } // Report Policy 
    }
}