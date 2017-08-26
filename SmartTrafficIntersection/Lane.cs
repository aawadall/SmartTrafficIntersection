using System;
namespace SmartTrafficIntersection
{
    // General Lane Superclass
    public class Lane : ILane
    {
        protected readonly IDirection _direction;
        protected readonly string _laneName;
        public Lane(IDirection direction, string name)
        {
            _direction = direction;
            _laneName = name;
        }
    }
}
