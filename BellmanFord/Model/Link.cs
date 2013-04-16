using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellmanFord.Model
{
    public class Link
    {
        private int cost;
        private IRouter target;
        private IRouter source;

        /// <summary>
        /// Adds a bi-directional link brtween two routers and registers it on each router
        /// </summary>
        /// <param name="Source">A source router</param>
        /// <param name="Target">A target router</param>
        /// <param name="Cost">Path cost</param>
        public Link(IRouter Source, IRouter Target, int Cost)
        {
            this.source = Source;
            this.target = Target;
            this.cost = Cost;

            Source.AddLink(this);
            Target.AddLink(this.Reverse());
        }

        /// <summary>
        /// Workarround use of private constructor to add reverse link - preventing stack overflow
        /// </summary>
        /// <param name="Source">Source Router</param>
        /// <param name="Target">Target Router</param>
        /// <param name="Cost">Link Cost</param>
        /// <param name="Reverse">Used purely for overloading</param>
        private Link(IRouter Source, IRouter Target, int Cost, bool Reverse)
        {
            this.source = Source;
            this.target = Target;
            this.cost = Cost;

   
        }

        /// <summary>
        /// Creates a reverse of a link without registering it
        /// </summary>
        /// <returns></returns>
        public Link Reverse()
        {
            return new Link(target, source, cost, true);
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
