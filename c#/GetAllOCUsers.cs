using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace TestPCUser
{
    class Program
    {
        static void Main(string[] args)
        {
            SelectQuery query = new SelectQuery("Win32_GroupUser");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            foreach (ManagementObject envVar in searcher.Get())
                Console.WriteLine("Record: {0}", envVar["PartComponent"]);

            Console.ReadLine();
        }
    }
}
