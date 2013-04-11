using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BellmanFord.Model
{
    class Router : IRouter
    {
        private List<Link> links;
        private Dictionary<IRouter, RoutingTableEntry> table;


        public Router()
        {
            links = new List<Link>();
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

        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void CheckCost(IRouter From, IRouter To, int AdvertisedCost)
        {
            if (LowerCost(To, AdvertisedCost))
            {
                table[To] = new RoutingTableEntry(AdvertisedCost, links.Single(link => link.Target() == To));
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

        private Boolean HasEntry(IRouter Target)
        {
            if (table.Keys.Contains(Target))
            {
                return true;
            }
            return false;
        }

    }
}
