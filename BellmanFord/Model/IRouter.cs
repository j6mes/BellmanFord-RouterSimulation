using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BellmanFord.Model
{
    interface IRouter
    {
        void Interate();
        void CheckCost(IRouter From, IRouter To, int Cost);
        void AddLink(Link Link);
    }
}
