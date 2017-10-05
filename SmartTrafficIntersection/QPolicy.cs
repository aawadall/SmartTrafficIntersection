using System;
namespace SmartTrafficIntersection
{
    public class QPolicy : Policy
    {
        protected double[,] _q;
        protected double _epsilon = 0.0;
        public QPolicy(int states, int actions, double alpha, double gamma) : base(states, actions, alpha, gamma)
        {
            _q = new double[_states,_actions];
        }

        public override void Learn(int state1, int state2, int action, double reward)
        {
            double maxState = _q[state2,0];
            for(int i=0;i<_actions;i++)
                maxState = _q[state2,i] > maxState ? _q[state2,i] : maxState;
            _q[state1,action] += _alpha * (reward + _gamma * maxState - _q[state1,action]);
        }

        public override int GetBestMove(int state)
        {
            // Exploration Chance 
            if (Policy.rnd.NextDouble() > _epsilon)
            {
                return Policy.rnd.Next(_actions);
            }

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

        public override void Report()
        {
            // Print Q Matrix
            for(int i=0;i<_states;i++)
            {
                Console.Write(String.Format(
                    "[{0}]\t",i
                ));
                for(int j=0;j<_actions;j++)
                {
                    Console.Write(String.Format(
                        "\t{0:0.00}",
                        _q[i,j]
                    ));
                }
                Console.WriteLine();
            }
            // Print Alpha, Gamma, Epsilon
            Console.WriteLine(String.Format(
                "alpha: {0}\tgamma: {1}\tepsilon{2}",
                _alpha,
                _gamma,
                _epsilon
            ));
        }
    }
}
