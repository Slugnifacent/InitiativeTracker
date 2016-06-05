using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    class Condition
    {
        string details;
        public Condition(string Details) {
            details = Details;
        }

        public string Details
        {
               get { return details; }
        }

        public string toString()
        {
            return details;
        }

    }
}
