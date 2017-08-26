using System;
namespace SmartTrafficIntersection
{
    // Traffic Light Interface 
    public interface ITrafficLight
    {
        bool IsAllowed(IDirection direction); // Is traffic Allowed for that direction?
        bool IsIncomingTraffic(IDirection direction); // Is there incoming traffic I have to look after?
        IDirection IncomingTraffic(IDirection direction); // What direction is my incoming traffic?
        void ControlTraffic(int ControlSignal); // Control Traffic Light

    }
}
