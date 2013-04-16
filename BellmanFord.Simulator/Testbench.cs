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
        List<Thread> RouterThreads;
        public Testbench()
        {
            Routers = new List<IRouterStatus>();
            IterableRouters = new List<IIteratable>();
            
        }
        public void AddRouter(IRouterStatus RouterStatus, IIteratable Iterator)
        {
            Routers.Add(RouterStatus);
            IterableRouters.Add(Iterator);
   
        }

        public void Interate()
        {
            RouterThreads = new List<Thread>();

            foreach (IIteratable router in IterableRouters)
            {
                RouterThreads.Add(new Thread(router.Interate));
     
            }

            foreach (Thread router in RouterThreads)
            {
                router.Start();

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
            Console.Beep();
        }
    }
}
