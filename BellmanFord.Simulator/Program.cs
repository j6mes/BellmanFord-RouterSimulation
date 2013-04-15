using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BellmanFord.Model;

namespace BellmanFord.Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Testbench app = new Testbench();


            Router[] routers = new Router[7];

            routers[0] = new Router("r1");
            routers[1] = new Router("r2");
            routers[2] = new Router("r3");
            routers[3] = new Router("r4");
            routers[4] = new Router("r5");
            routers[5] = new Router("r6");
            routers[6] = new Router("r7");

            Link[] links = new Link[9];

            links[0] = new Link(routers[0], routers[1], 2);
            links[1] = new Link(routers[0], routers[4], 4);
            links[2] = new Link(routers[1], routers[2], 4);
            links[3] = new Link(routers[1], routers[3], 2);
            links[4] = new Link(routers[1], routers[4], 1);
            links[5] = new Link(routers[2], routers[5], 2);
            links[6] = new Link(routers[3], routers[5], 3);
            links[7] = new Link(routers[4], routers[6], 1);
            links[8] = new Link(routers[5], routers[6], 1);


            foreach (Router router in routers)
            {
                router.InitializeAllLinks();
                app.AddRouter(router, router);
            }



            while (true)
            {
                Console.Clear();


                Console.WriteLine("Bellman-Ford Spanning Tree Solver\nJames Thorne. University of York 2013\nhttp://james.thorne.jp\n\n");
                    

                app.Interate();
                Console.ReadLine();
            }
           

        }

       
    }
}
