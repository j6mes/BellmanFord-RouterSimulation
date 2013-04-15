using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BellmanFord.Controller;
using BellmanFord.View;

namespace BellmanFord.Simulator
{
    class Testbench : IIteratable
    {
        List<IRouterStatus> Routers;
        List<IIteratable> IterableRouters;

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
        }
    }
}
