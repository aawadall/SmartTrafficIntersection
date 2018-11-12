namespace SmartTrafficIntersection.sim
{
    // Nothing interesting here yet
    public interface IIntersection
    {
        void Simulate();
        int TotalWaitTime();
        void Control(int controlSignal); // Control Signal is a bitmap
        int State(); // Current State of the Intersection in terms of Traffic Controllers 
        void AlterFlow(int laneIndex, int inFlowDelta, int outFlowDelta);

    }
}
