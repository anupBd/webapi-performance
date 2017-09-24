using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace PerformanceTest.Controllers
{
    public class ThreadingController : AsyncController
    {

        public ThreadPoolInfo Get()
        {
            int availableWorker, availableIO;
            int maxWorker, maxIO;

            ThreadPool.GetAvailableThreads(out availableWorker, out availableIO);
            ThreadPool.GetMaxThreads(out maxWorker, out maxIO);

            return new ThreadPoolInfo
            {
                AvailableWorkerThreads = availableWorker,
                MaxWorkerThreads = maxWorker,
                OccupiedThreads = maxWorker - availableWorker
            };
        }

        // GET: /Threading/Ussage
        [Route("Threading/Ussage")]
        public string Ussage()
        {
            return "1: /sleepthread/id | 2: /threadsinfo | 3: /SleepThreadWithIISDetatched/id";
        }

        // GET: /Threading/SleepThread/Id
        public int SleepThread(int id)
        {
            Thread.Sleep(20000);
            return id;
        }

        // GET: /Threading/Settings
        public string Settings()
        {
            int minWorker, minIOC;
            ThreadPool.GetMinThreads(out minWorker, out minIOC);

            if (ThreadPool.SetMinThreads(300, minIOC)) // <<<<< -------------------------------------------------
            {
                // The minimum number of threads was set successfully.
                return "The minimum number of threads was set successfully.";
            }
            else
            {
                // The minimum number of threads was not changed.
                return "The minimum number of threads was not changed.";
            }

        }

        // GET: /threading/SleepThreadWithIISDetatched/
        public void SleepThreadWithIISDetatchedAsync(int id)
        {
            AsyncManager.OutstandingOperations.Increment();

            Thread.Sleep(20000);

            AsyncManager.Parameters["id"] = id;

            AsyncManager.OutstandingOperations.Decrement();

        }

        public int SleepThreadWithIISDetatchedCompleted(int id)
        {
            return id;
        }

        // GET: /Threading/ThreadsInfo
        public string ThreadsInfo()
        {
            int availableWorker, availableIO;
            int maxWorker, maxIO;

            ThreadPool.GetAvailableThreads(out availableWorker, out availableIO);
            ThreadPool.GetMaxThreads(out maxWorker, out maxIO);

            return new ThreadPoolInfo
            {
                AvailableWorkerThreads = availableWorker,
                MaxWorkerThreads = maxWorker,
                OccupiedThreads = maxWorker - availableWorker
            }.StringValue();
        }

       
    }
}