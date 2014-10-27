using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://localhost:8888";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Web app starting at " + url);
                Console.ReadLine();
            }
        }
    }
}
