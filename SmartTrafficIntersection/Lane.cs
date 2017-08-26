namespace SmartTrafficIntersection
{
    // General Lane Superclass
    public class Lane : ILane
    {
        protected readonly IDirection _direction;
        protected readonly string _laneName;
        protected Simulator _sim;
        private int _inFlow=3;
        private int _outFlow=3;
        private int _initialTraffic=3;

        public int InFlow { get { return _inFlow;} set  {_inFlow = value; }}
        public int OutFlow { get { return _outFlow;} set { _outFlow = value; }}
        public int InitialTraffic { get { return _initialTraffic;} set { _initialTraffic = value; }}

        public Lane(string name, Direction direction, int inFlow, int outFlow, int initialTraffic)
        {
            _direction = direction;
            _laneName = name;
            _inFlow = inFlow;
            _outFlow = outFlow;
            _initialTraffic = initialTraffic;
            _sim = new Simulator(_initialTraffic, _inFlow, _outFlow);
        }

        public Lane(string name, Direction direction) : this(name, direction, 0, 0, 0)
        {}

        // Simulator 
        public void Simulate(TrafficController controller)
        {
            _sim.SimulateTraffic(controller.IsAllowed(_direction), controller.IsRisky(_direction));
        }

        // Wait Time 
        public int WaitTime {get{return _sim.WaitTime;}}
    }
}
