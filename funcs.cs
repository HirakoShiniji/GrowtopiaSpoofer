using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GrowtopiaSpoofer
{
    class funcs
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, long lpAddress,
 long dwSize, uint flAllocationType, uint flProtect);


        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern int WriteProcessMemory(IntPtr Handle, long Address, byte[] buffer, int Size, int BytesWritten = 0);
        [DllImport("kernel32.dll")]
        public static extern int WriteProcessMemory(IntPtr Handle, long Address, Int32 buffer, int Size, int BytesWritten = 0);
        [DllImport("kernel32.dll")]
        public static extern int ReadProcessMemory(IntPtr Handle, long Address, byte[] buffer, int Size, int BytesRead = 0);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool VirtualProtectEx(IntPtr hProcess, long lpAddress,
          int dwSize, uint flNewProtect, out uint lpflOldProtect);
        static long client = 0;
        public const int
   PAGE_READWRITE = 0x40,
PROCESS_VM_OPERATION = 0x0008,
PROCESS_VM_READ = 0x0010,
PROCESS_VM_WRITE = 0x0020;

        static void Patch(long Address, byte[] enable, byte[] Disable)
        {

            Process gt = Process.GetProcessesByName("Growtopia")[0];
            IntPtr handler = OpenProcess(0x0FFFFF, true, gt.Id);
            var baseadd = gt.MainModule.BaseAddress.ToInt64();
            client = baseadd;
            uint kek;

            VirtualProtectEx(handler, client + 0x0, gt.MainModule.ModuleMemorySize, PAGE_READWRITE,
             out kek);
            VirtualAllocEx(handler, client + Address, enable.Length, 0x40, 0x40);

            WriteProcessMemory(handler, client + Address, enable, enable.Length, 0);
        }
        public static int replace(string func_name,string value)
        {
            if (func_name == "OnConnectPacket|")
            {
                Patch(list.located, ASCIIEncoding.ASCII.GetBytes(value), null);
            }
            if (func_name == "mac|")
            {
                Patch(list.func_mac_address, ASCIIEncoding.ASCII.GetBytes(value), null);
            }
            if (func_name == "platformID|")
            {
                Patch(list.platformID_address, ASCIIEncoding.ASCII.GetBytes(value), null);
            }
            if (func_name == "reconnect|")
            {
                Patch(list.reconnect, ASCIIEncoding.ASCII.GetBytes(value), null);
            }
            if (func_name == "game_version|")
            {
                float realver = 0;
                if (value.Contains("2.99"))
                {
                    float version = 2.819999933f;
                    realver = version;
                }
                if (value.Contains("3.30"))
                {
                    float version = 3.309999933f;
                    realver = version;
                }
                if (value.Contains("3.32"))
                {
                    float version = 3.319999933f;
                    realver = version;
                }
                if (value.Contains("3.33"))
                {
                    float version = 3.329999933f;
                    realver = version;
                }
                if (value.Contains("3.34"))
                {
                    float version = 3.349999933f;
                    realver = version;
                }
                if (value.Contains("3.35"))
                {
                    float version = 3.549999933f;
                    realver = version;
                }
                if (value.Contains("3.022"))
                {
                    float version = 3.019999933f;
                    realver = version;
                }
                byte[] test_version = BitConverter.GetBytes(realver);
                Events.version = value;
                Patch(list.game_version, test_version, null);
            }
            return 0;
        }
    }
}
