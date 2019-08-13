namespace SmartTrafficIntersection
{
    public interface IAgent
    {
        void Learn(int State1, int State2, int Action, int Reward);
        int GetBestMove(int State);
        void Report(); 
    }    
}
