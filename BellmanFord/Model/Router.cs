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

        public Router(String Name)
        {
            links = new List<Link>();
            table = new ConcurrentDictionary<IRouter, RoutingTableEntry>();
            name = Name;
        }


        public void AddLink(Link Link)
        {
            links.Add(Link);
           
        }

        
        public List<Link> Links()
        {
            return links;
        }


        public void Interate()
        {
            foreach (var link in links)
            {

                foreach(var entry in table)
                {
                    
                    link.Target().CheckCost(this, entry.Key, entry.Value.Cost());
                    
                }
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void CheckCost(IRouter From, IRouter To, int AdvertisedCost)
        {
            /*
             * Todo: check null arguments
             */
            if (To == this)
            {
                return;

            }

            Link sourcelink;
            int cost= AdvertisedCost;
            sourcelink = links.Single(link => link.Target() == From);

           
            cost = AdvertisedCost + sourcelink.Cost();
            

            if (LowerCost(To, cost))
            {
                
                table[To] = new RoutingTableEntry(AdvertisedCost + sourcelink.Cost(), sourcelink);
            }
            
        }


        private Boolean LowerCost(IRouter Target, int AdvertisedCost)
        {
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


        private void Initialize(IRouter Target)
        {
            table[Target] = new RoutingTableEntry(999, null);
        }

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
