using System;

namespace SmartTrafficIntersection
{
    public interface IPolicy
    {
        void Learn(int state1, int state2, int action, double reward);
        int GetBestMove(int state);
    }
}