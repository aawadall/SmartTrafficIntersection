namespace SmartTrafficIntersection.sim
{
    // Traffic Controller Interface 
    // This is a gernic conroller that can be a stop sign, a rowndabout, a traffic light or a human controller 
    public interface ITrafficController
    {
        bool IsAllowed(IDirection direction); // Is traffic Allowed for that direction?
        bool IsRisky(IDirection direction); // Is traffic at that direction risky?
        bool IsIncomingTraffic(IDirection direction); // Is there incoming traffic I have to look after?
        IDirection IncomingTraffic(IDirection direction); // What direction is my incoming traffic?
        void ControlTraffic(int ControlSignal); // Control Traffic Controller
        void Flip();
        string Status();
    }
}
