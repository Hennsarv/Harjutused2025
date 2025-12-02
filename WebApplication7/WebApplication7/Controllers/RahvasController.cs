using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class RahvasController : ApiController
    {
        // GET: api/Rahvas
        public IEnumerable<Inimene> Get()
        {
            //return new string[] { "value1", "value2" };
            return InimeneController.Inimesed;
        }

        // GET: api/Rahvas/5
        public Inimene Get(int id)
        {
            return InimeneController.Inimesed.FirstOrDefault(x => x.Id == id);
        }

        // POST: api/Rahvas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Rahvas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Rahvas/5
        public void Delete(int id)
        {
        }
    }
}
