using System.Collections.Generic;

namespace SmartTrafficIntersection
{
    // Intersection Superclass
    public class Intersection : IIntersection
	{
		// An Intersection should have a set of lanes with different directions, and a set of traffic lights controlling them
		protected List<Direction> _directions;
		protected List<TrafficController> _trafficControllers;
        protected List<Lane> _lanes;

    }
}
