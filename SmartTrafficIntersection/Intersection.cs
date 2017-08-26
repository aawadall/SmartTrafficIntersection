using System;
using System.Linq;
using System.Collections.Generic;

namespace SmartTrafficIntersection
{
	// Intersection Superclass
	public class Intersection
	{
		// An Intersection should have a set of lanes with different directions, and a set of traffic lights controlling them
		protected List<IDirection> _directions;
		protected List<ITrafficController> _trafficControllers;
        protected List<Lane> _lanes;

	}
}
