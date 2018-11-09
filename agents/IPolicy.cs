using System;

namespace SmartTrafficIntersection.agents
{
    public interface IPolicy
    {
        void Learn(int state1, int state2, int action, double reward);
        int GetBestMove(int state);
        void Report(); // Prints out policy statistics 
    }
}