using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PerformanceTest
{
    public class ThreadPoolInfo
    {
        public int AvailableWorkerThreads { get; set; }
        public int MaxWorkerThreads { get; set; }
        public int OccupiedThreads { get; set; }

        public string StringValue()
        {
            return "available: " + AvailableWorkerThreads + " | max: " + MaxWorkerThreads + " | occupied: " + OccupiedThreads;
        }
    }
}