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
        private IRouter target;
        private IRouter source;

        public Link(IRouter Source, IRouter Target, int Cost)
        {
            this.source = Source;
            this.target = Target;
            this.cost = Cost;

            Source.AddLink(this);
            Target.AddLink(this);
        }

        public IRouter Target()
        {
            return target;
        }

        public IRouter Source()
        {
            return source;
        }

        public int Cost()
        {
            return cost;
        }
    }
}
