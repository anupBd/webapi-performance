using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;

namespace PerformanceTest.Controllers
{
    public class TestController : ApiController
    {
        private HttpClient client;

        public TestController()
        {
            this.client = new HttpClient();
        }

        // GET: api/Test
        [Route("api/Test")]
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

        // GET: api/Test/5
        public string Get(int id)
        {
            //   var k = await this.client.GetAsync("https://google.com");
            //   // var x = await k.Content.ReadAsStringAsync();
            Thread.Sleep(10000);
            return "value";

        }

        // POST: api/Test
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
    }

}
