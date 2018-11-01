using System;

namespace SmartTrafficIntersection
{
    // Traffic Controller Interface 
    // This is a gernic conroller that can be a stop sign, a rowndabout, a traffic light or a human controller 
    public class TrafficController : ITrafficController
    {
        protected readonly Direction _direction;
        protected readonly Direction _riskyDirection;
        protected readonly string _controllerName;
        protected bool _allowed;

        public bool Allowed { get {return _allowed;} set {_allowed = value; }}

        public TrafficController(string name, Direction direction, Direction riskyDirection)
        {
            _controllerName = name;
            _direction = direction;
            _riskyDirection = riskyDirection;
        }

        public TrafficController(string name, Direction direction) : this(name, direction, null){}

        public bool IsAllowed(IDirection direction)
        {
            return (_allowed && 
            (direction == _direction || 
             direction == _riskyDirection));
        } // Is traffic Allowed for that direction?
        public bool IsRisky(IDirection direction){
            return direction == _riskyDirection;
        } // Is traffic at that direction risky?
        public bool IsIncomingTraffic(IDirection direction){
            return _allowed;
        } // Is there incoming traffic I have to look after?
        public IDirection IncomingTraffic(IDirection direction){
            return null;
        } // What direction is my incoming traffic?
        public void ControlTraffic(int ControlSignal){
            // Not implemented yet
            throw new NotImplementedException();
        } // Control Traffic Controller

        public void Flip()
        {
            _allowed = !_allowed;
        }

        public string Status()
        {
            return _allowed?"Allowed":"Not Allowed";
        } 
    }
}
