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
            IRouter r1 = new Router();
            IRouter r2 = new Router();

            Link r1r2 = new Link(r1, r2, 5);

            r1.InitializeAllLinks();
            r2.InitializeAllLinks(); 


            r1.Interate();
            r2.Interate();



        }
    }
}
