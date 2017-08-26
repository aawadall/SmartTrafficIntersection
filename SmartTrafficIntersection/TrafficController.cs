namespace SmartTrafficIntersection
{
    // Traffic Controller Interface 
    // This is a gernic conroller that can be a stop sign, a rowndabout, a traffic light or a human controller 
    public class TrafficController : ITrafficController
    {
        protected readonly Direction _direction;
        protected readonly string _controllerName;
        public TrafficController(string name, Direction direction)
        {
            _controllerName = name;
            _direction = direction;
        }

        public bool IsAllowed(IDirection direction)
        {
            return false;
        } // Is traffic Allowed for that direction?
        public bool IsRisky(IDirection direction){
            return false;
        } // Is traffic at that direction risky?
        public bool IsIncomingTraffic(IDirection direction){
            return false;
        } // Is there incoming traffic I have to look after?
        public IDirection IncomingTraffic(IDirection direction){
            return null;
        } // What direction is my incoming traffic?
        public void ControlTraffic(int ControlSignal){
            
        } // Control Traffic Controller
    }
}
