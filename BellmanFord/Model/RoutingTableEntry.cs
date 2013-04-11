using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellmanFord.Model
{
    class RoutingTableEntry
    {
        public Router Target;
        public int TotalCost;
        public Link Destination;

        public RoutingTableEntry(Router Target, int TotalCost, Link Destination)
        {
            this.Target = Target;
            this.TotalCost = TotalCost;
            this.Destination = Destination;
        }
    }
}
