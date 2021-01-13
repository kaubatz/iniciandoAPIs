using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace primeiraAPI.Controllers
{
    [Route("api/webservice")]
    //[ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/webservice
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/webservice/lercliente/5
        [HttpGet("{id}")]
        [Route("lercliente/{id}")]
        public ActionResult<string> LerCliente(int id)
        {
            // return "value";
            return id.ToString(); 
        }

        // POST api/webservice/gravardados
        [HttpPost]
        [Route("gravardados")]
        public string GravarDados([FromBody] string value)
        {
            return "ok";
        }

        // PUT api/webservice/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
