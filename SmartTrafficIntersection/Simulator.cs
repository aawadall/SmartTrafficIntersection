using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartTrafficIntersection
{
    // Simulates Traffic 
    public class Simulator
    {
        protected Queue<int> _waitTime;

        public Simulator(int initialLength)
        {
            _waitTime = new Queue<int>(initialLength);
        }

        public Simulator() : this(0)
        {}
    }
}