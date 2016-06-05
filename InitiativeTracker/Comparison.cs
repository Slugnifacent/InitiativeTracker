using InitiativeTracker.WindowUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    class Comparison
    {
        private static Comparison compare;

        private Comparison() { }

        public Comparison Instance()
        {
            if (compare == null)
            {
                compare = new Comparison();
            }
            return compare;
        }
        

    }


}
