using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BellmanFord.Controller;
using BellmanFord.View;
using System.Threading;

namespace BellmanFord.Simulator
{
    class Testbench : IIteratable
    {
        List<IRouterStatus> Routers;
        List<IIteratable> IterableRouters;

        public Testbench()
        {
            Routers = new List<IRouterStatus>();
            IterableRouters = new List<IIteratable>();
        }
        public void AddRouter(IRouterStatus RouterName, IIteratable Iterator)
        {
            Routers.Add(RouterName);
            IterableRouters.Add(Iterator);
        }

        public void Interate()
        {
            foreach (IIteratable router in IterableRouters)
            {
                router.Interate();
            }


            foreach (IRouterStatus router in Routers)
            {
                Print(router);
            }
            
        }

        public void Print(IRouterStatus Router)
        {
            Console.WriteLine("Router " + Router.Name());
            foreach (var entry in Router.RoutingTable().Keys)
            {
                Console.WriteLine(entry.Name() + " - " + Router.RoutingTable()[entry].Cost() +  ","+ Router.RoutingTable()[entry].Target().Name());
                      
            }
            Console.WriteLine("");
            
        }
    }
}
