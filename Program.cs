using System;

namespace Process_killer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Run with three parameters:\n1. Name of the process.\n2. Timer until the end of the process life.\n3. Periodicity of checking the life of the process.");
                Environment.Exit(0);
            }
            string processName = args[0];
            uint lifeTime = Convert.ToUInt32(args[1]);
            uint сheckFrequency = Convert.ToUInt32(args[2]);

            ProcessKiller processKiller = new ProcessKiller(processName, lifeTime, сheckFrequency);
        }
    }
}
