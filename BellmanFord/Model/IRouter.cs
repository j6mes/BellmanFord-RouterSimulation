using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BellmanFord.Controller;
using BellmanFord.View;

namespace BellmanFord.Model
{
    public interface IRouter : INamedObject, IIteratable, IRoutingTable
    {
        void CheckCost(IRouter From, IRouter To, int Cost);
        void AddLink(Link Link);
        void InitializeAllLinks();
       
    }
}
