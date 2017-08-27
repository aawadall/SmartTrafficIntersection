using System.Collections.Generic;
using System.Linq;

namespace SmartTrafficIntersection
{
    // Simple 4 Directions Intersection (N, W, S, E)
    public class FourDirectionIntersection : Intersection
    {

        public FourDirectionIntersection() 
        {
            // Define Directions
            _directions = new List<Direction>()
            {
                new Direction("Direction 0: Northbound"),
                new Direction("Direction 1: Eastbound"),
                new Direction("Direction 2: Southbound"),
                new Direction("Direction 3: Westbound"),
            };
            
            // Define Lanes
            _lanes = new List<Lane>()
            {
                new Lane("Lane 0 : Southbound",_directions[0],5,10,0),
                new Lane("Lane 1 : Wesboundt" ,_directions[1],1,3,0),
                new Lane("Lane 2 : Northbound",_directions[2],4,11,0),
                new Lane("Lane 3 : Eastbound" ,_directions[3],1,3,0),
            };
            // Define Traffic Controllers 
            _trafficControllers = new List<TrafficController>()
            {
                new TrafficController("Light 0 : Southbound",_directions[0]),
                new TrafficController("Light 1 : Westbound" ,_directions[1]),
                new TrafficController("Light 2 : Northbound",_directions[2]),
                new TrafficController("Light 3 : Eastbound" ,_directions[3])
            }; 
        }
    }
}
