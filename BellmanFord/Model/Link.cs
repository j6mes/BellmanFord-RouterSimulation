using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellmanFord.Model
{
    class Link
    {
        private int cost;
        private Router target;
        private Router source;

        public Link(Router Source, Router Target, int Cost)
        {
            this.source = Source;
            this.target = Target;
            this.cost = Cost;

            Source.AddLink(this);
            Target.AddLink(this);
        }
    }
}
