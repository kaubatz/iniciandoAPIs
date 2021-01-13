using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Util;
using System.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class ClienteController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            DAL objDAL = new DAL();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            DAL objDAL = new DAL();
            string sql = $"select * from cliente where id = {id}";
            DataTable dados = objDAL.RetornaDataTable(sql);

            //return "value";
            return dados.Rows[0]["nome"].ToString();
        }

        // POST api/values
        [HttpPost]
        [Route("registrarcliente")]
        public ReturnAllServices RegistrarCliente([FromBody] ClienteModel dados)
        {
            ReturnAllServices retorno = new ReturnAllServices();

            try
            {
                dados.RegistrarCliente();
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
            }
            catch(Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro ao registrar cliente: " + ex.Message;
            }

            return retorno;
        }

        // PUT api/values/5
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
