using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellmanFord.Model
{
    class RoutingTableEntry
    {
        
        private int TotalCost;
        private Link Destination;

        public RoutingTableEntry(int TotalCost, Link Destination)
        {
            
            this.TotalCost = TotalCost;

            
                this.Destination = Destination;
            
        }

        public int Cost()
        {
            return TotalCost;
        }
    }
}
