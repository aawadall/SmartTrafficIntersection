using System;
namespace SmartTrafficIntersection
{
    public class Policy : IPolicy
    {
        protected double _alpha;
        protected double _gamma;
        public static Random rnd = new Random();
        // State Action Space
        protected int _states;
        protected int _actions;
        public Policy(int states, int actions, double alpha, double gamma)
        {
            _states = states;
            _actions = actions;
            _alpha = alpha;
            _gamma = gamma;
        }

        public virtual void Learn(int state1, int state2, int action, double reward)
        {

        }
        public virtual int GetBestMove(int state)
        {
            return 0;
        }

        public virtual void Report()
        {

        }
    }
}