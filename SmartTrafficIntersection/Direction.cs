using System;
namespace SmartTrafficIntersection
{
    /* Direction Class, 
     * typically a simple class containing only a name, 
     * with no significance yet to real direction  */
    public class Direction : IDirection
    {
        protected readonly string _directionName;
        public string Name {get{return _directionName;}}

        public Direction(string name)
        {
            _directionName = name;
        }
    }
}
