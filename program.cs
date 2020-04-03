using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GrowtopiaSpoofer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GrowtopiaSpoofer by Hirako#4480"); Console.WriteLine("HTTP Server is running!");
            Console.Title("GrowtopiaSpoofer by Hirako#4480");
         
            HTTP.gtfakeserver = new HttpListener();
            HTTP.gtfakeserver.Prefixes.Add(HTTP.url);

            HTTP.Spoofer();

        }
    }
}
