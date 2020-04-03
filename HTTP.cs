using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GrowtopiaSpoofer
{
    class HTTP
    {
        public static HttpListener gtfakeserver;



        public static string url = "http://127.0.0.1:80/growtopia/server_data.php/";
        public static bool go = false;


        public static HttpListener web = new HttpListener();


        public static void Spoofer()
        {
            string server_data = "server|" + "209.59.191.76" + "\n" +
    "port|" + "16999" + "\n" +
    "type|1\n" +
    "#maint|GrowtopiaSpoofer by Hirako#4480\n" +
    "beta_server|beta.growtopiagame.com\n" +
    "beta_port|1945\n" +
    "beta_type|1\n" +
    "meta|ni.com\n" +
    "RTENDMARKERBS1001\n";




            web.Prefixes.Add(url);

            web.Start();



            var context = web.GetContext();

            var response = context.Response;



            var buffer = System.Text.Encoding.UTF8.GetBytes(server_data);
            Events.Spoof();


            go = true;

            response.ContentLength64 = buffer.Length;

            var output = response.OutputStream;

            output.Write(buffer, 0, buffer.Length);
         


            output.Close();

            web.Stop();
            System.Threading.Thread.Sleep(2000);

            go = false;
     
            Spoofer();
        }

    }
}
