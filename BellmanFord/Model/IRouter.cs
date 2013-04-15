using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BellmanFord.Controller;
using BellmanFord.View;

namespace BellmanFord.Model
{
    public interface IRouter : IRouterStatus, IIteratable
    {
        void CheckCost(IRouter From, IRouter To, int Cost);
        void AddLink(Link Link);
        void InitializeAllLinks();
       
    }
}
