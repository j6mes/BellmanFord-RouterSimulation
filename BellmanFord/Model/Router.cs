using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellmanFord.Model
{
    class Router
    {
        private List<Link> links;

        public Router()
        {
            links = new List<Link>();
        }


        public void AddLink(Link Link)
        {
            links.Add(Link);
        }

        public List<Link> Links()
        {
            return links;
        }
    }
}
