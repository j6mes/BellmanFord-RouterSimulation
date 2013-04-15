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
        List<INamedObject> RouterNames;
        List<IIteratable> IterableRouters;

        public void AddRouter(INamedObject RouterName, IIteratable Iterator)
        {
            RouterNames.Add(RouterName);
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
