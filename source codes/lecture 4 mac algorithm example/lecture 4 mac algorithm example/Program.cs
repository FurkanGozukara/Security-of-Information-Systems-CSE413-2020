using System;
using static lecture_4_mac_algorithm_example.hmac;
using System.IO;

namespace lecture_4_mac_algorithm_example
{
    class Program
    {
        static void Main(string[] args)
        {
            string srKey = File.ReadAllText("key.txt");
            string srMac = computeMacValue(File.ReadAllText("some long text.txt"), srKey);
            receiver(File.ReadAllText("some long text.txt"), srMac);
            Console.Read();
        }

        static void receiver(string srMsg, string srMac)
        {
            string srKey = File.ReadAllText("key.txt");
            string srMacReCalculate= computeMacValue(srMsg, srKey);
            if(srMacReCalculate== srMac)
            {
                Console.WriteLine("received message was authentic and not forged");
                Console.WriteLine("received mac value: "+ srMac);
                Console.WriteLine("new computed mac value: " + srMacReCalculate);
            }
        }
    }
}
