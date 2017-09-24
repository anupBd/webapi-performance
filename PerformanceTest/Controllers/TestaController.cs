using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace PerformanceTest.Controllers
{
    public class TestaController : AsyncController
    {
        // GET: api/Testa
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Testa/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Testa
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Testa/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Testa/5
        public void Delete(int id)
        {
        }
    }
}
