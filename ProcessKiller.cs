using System;
using System.Diagnostics;
using System.Threading;

namespace Process_killer
{
    internal class ProcessKiller
    {
        private string Name { get; }

        private uint LifeTime { get; }

        private uint CheckFrequency { get; }

        private DateTime LifeTimeEnd { get; set; }

        public ProcessKiller(string processName, uint lifeTime, uint сheckFrequency)
        {
            Name = processName;
            LifeTime = lifeTime;
            CheckFrequency = сheckFrequency;
            StartCheckTimer();
        }

        public void StartCheckTimer()
        {
            Timer checkProcessTimer = new Timer(CheckProcess, null, 0, CheckFrequency * 60000);
            Console.ReadLine();
        }

        private void CheckProcess(Object obj)
        {
            try
            {
                Process[] process = Process.GetProcessesByName(Name);
                Console.WriteLine($"Spy the process: { process[0].ProcessName}");

                if (LifeTimeEnd.Equals(DateTime.MinValue))
                {
                    LifeTimeEnd = DateTime.Now;
                    LifeTimeEnd = LifeTimeEnd.AddMinutes(LifeTime);
                }
                else if (LifeTimeEnd.TimeOfDay <= DateTime.Now.TimeOfDay)
                {
                    foreach (var item in process)
                        item.Kill();
                    Console.WriteLine($"Process was killed at {DateTime.Now.TimeOfDay}");
                    Environment.Exit(0);
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Process not found!");
            }

        }
    }
}
