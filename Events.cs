using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GrowtopiaSpoofer
{
    class Events
    {
        public static string version = "";

        public static void Spoof()
        {
            //to be implemented!
            Console.WriteLine("[HTTP] got server data request!");
            Console.WriteLine("[GrowtopiaSpoofer] Spoofing user info...");

            
            funcs.replace("game_version|", "3.32");
            funcs.replace("OnConnectPacket|", "`4[HiraSpoofer] ``Spoofed User Info!\n`0[S] ``GT Version: " + version + "              ");
            funcs.replace("mac|", "0");
            funcs.replace("platformID|", "4"); //android
            funcs.replace("reconnect|", "1"); //dont touch this else you will not be able to connect
            
            Console.WriteLine("[GrowtopiaSpoofer] game_version|" + version);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("[GrowtopiaSpoofer] event|OnSendToServer");

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
       

       
            
               
            
            
          


        
    

