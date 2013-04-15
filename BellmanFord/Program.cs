using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BellmanFord.Model;


namespace BellmanFord
{
    class Program
    {
        static void Main(string[] args)
        {
            IRouter r1 = new Router("r1");
            IRouter r2 = new Router("r2");
            IRouter r3 = new Router("r3");
            Link r1r2 = new Link(r1, r2, 3);
            Link r2r3 = new Link(r2, r3, 5);

            r1.InitializeAllLinks();
            r2.InitializeAllLinks();
            r3.InitializeAllLinks(); 

            r1.Interate();
            r2.Interate();
            r3.Interate();

            r1.Interate();
            r2.Interate();
            r3.Interate();

        }
    }
}
