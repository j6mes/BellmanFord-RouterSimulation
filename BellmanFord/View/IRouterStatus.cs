using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellmanFord.View
{
    public interface IRouterStatus : IRoutingTable
    {
        String Name();
    }
}
