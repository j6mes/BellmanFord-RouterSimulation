using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BellmanFord.View;
using CuttingEdge;
using System.Collections.Concurrent;

namespace BellmanFord.Model
{
    public class Router : IRouter
    {
        private List<Link> links;
        private ConcurrentDictionary<IRouter, RoutingTableEntry> table;
        private String name;

        /// <summary>
        /// Creates a new router with a name
        /// </summary>
        /// <param name="Name">Router's friendly name</param>
        public Router(String Name)
        {
            links = new List<Link>();
            table = new ConcurrentDictionary<IRouter, RoutingTableEntry>();
            name = Name;
        }

        /// <summary>
        /// Registers a link added to the router
        /// </summary>
        /// <param name="Link">Link to be registered</param>
        public void AddLink(Link Link)
        {
            links.Add(Link);
           
        }

        
        public List<Link> Links()
        {
            return links;
        }

        /// <summary>
        /// Broadcast routing table to all neighbours
        /// </summary>
        public void Iterate()
        {
            foreach (var link in links)
            {
                foreach(var entry in table)
                {
                    
                    link.Target().CheckCost(this, entry.Key, entry.Value.Cost());
                    
                }
            }
        }

        /// <summary>
        /// Receive broadcast message
        /// Synchronized 
        /// </summary>
        /// <param name="From">The sending router. The nexthop</param>
        /// <param name="To">The destination router</param>
        /// <param name="AdvertisedCost">Advertised cost from sending router</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void CheckCost(IRouter From, IRouter To, int AdvertisedCost)
        {
            if (From == null || To == null)
            {
                throw new ArgumentNullException("Null router given");
            }


            if (To == this)
            {
                //Do Nothing
                return;
            }

            /*
             * Get the link that the message is from.
             * Check that we actually link to it
             */
            Link sourcelink;
            int cost= AdvertisedCost;

            sourcelink = links.SingleOrDefault(link => link.Target() == From);
            if (sourcelink == null)
            {
                throw new ArgumentException("This rouer doesn't link to sending router");
            }
           

            /*
             * Add local edge cost advertised cost
             */
            cost += sourcelink.Cost();
            

            /*
             * If this costs less, add it to the routing table
             */
            if (LowerCost(To, cost))
            { 
                table[To] = new RoutingTableEntry(AdvertisedCost + sourcelink.Cost(), sourcelink);
            }
            
        }

        /// <summary>
        /// Checks if a route cost is minimal
        /// </summary>
        /// <param name="Target">Target router</param>
        /// <param name="AdvertisedCost">Current cost</param>
        /// <returns>True if the route cost is minimal</returns>
        private Boolean LowerCost(IRouter Target, int AdvertisedCost)
        {
            /*
             * Check route exists in routing table, else add it and return true
             */
            if (HasEntry(Target))
            {
                if (table[Target].Cost() > AdvertisedCost)
                {
                    return true;
                }

                return false;
            }


            Initialize(Target);
            return true;
        }

        /// <summary>
        /// Initialize an entry in the routing table from a router
        /// </summary>
        /// <param name="Target">Router to add with null next hop</param>
        private void Initialize(IRouter Target)
        {
            table[Target] = new RoutingTableEntry(999, null);
        }

        /// <summary>
        /// Initialize an entry in the routing table from a link
        /// </summary>
        /// <param name="Dest">Target = link.target</param>
        private void Initialize(Link Dest)
        {
            table[Dest.Target()] = new RoutingTableEntry(Dest.Cost(), Dest);
        }


        private Boolean HasEntry(IRouter Target)
        {
            if (table.Keys.Contains(Target))
            {
                return true;
            }
            return false;
        }



        public void InitializeAllLinks()
        {
            foreach (var link in links)
            {
                Initialize(link);
            }

        }

        public String Name()
        {
            return name;
        }




        public ReadOnlyDictionary<IRouterStatus, RoutingTableEntry> RoutingTable()
        {

            Dictionary<IRouterStatus, RoutingTableEntry> newTable = new Dictionary<IRouterStatus, RoutingTableEntry>();

            foreach (IRouter router in table.Keys)
            {
                newTable[router] = table[router];
            }

            return new ReadOnlyDictionary<IRouterStatus, RoutingTableEntry>(newTable);
        }
    }
}
