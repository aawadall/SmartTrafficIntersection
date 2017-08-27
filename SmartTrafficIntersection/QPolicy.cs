using System;
namespace SmartTrafficIntersection
{
    public class QPolicy : Policy
    {
        protected double[,] _q;
        protected double _epsilon = 0.01;
        public QPolicy(int states, int actions, double alpha, double gamma) : base(states, actions, alpha, gamma)
        {
            _q = new double[_states,_actions];
        }

        public override void Learn(int state1, int state2, int action, double reward)
        {
            Console.WriteLine(String.Format("Inside Learn, S {0} S' {1} a {2}",state1,state2,action));
            double maxState = _q[state2,0];
            for(int i=0;i<_actions;i++)
                maxState = _q[state2,i] > maxState ? _q[state2,i] : maxState;
            Console.WriteLine(String.Format("Maximum Q For State [{0}] : {1}",state2,maxState));
            _q[state1,action] += _alpha * (reward + _gamma * maxState - _q[state1,action]);
        }

        public override int GetBestMove(int state)
        {
            // Exploration Chance 
            if (Policy.rnd.NextDouble() > _epsilon)
                return Policy.rnd.Next(_actions);

            // Normal Q State
            double maxState = _q[state,0];
            int index = 0;
            for(int i=0;i<_actions;i++)
            {
                index = _q[state,i] > maxState ?i:index;
                maxState = _q[state,i] > maxState ? _q[state,i] : maxState;
            }
            return index;
        }
    }
}