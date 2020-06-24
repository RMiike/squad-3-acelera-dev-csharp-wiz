using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CentralDeErro.Api.Controllers.v1
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AccountManageController : ControllerBase
    {
        //Alterar dados da conta/ senha

        // GET: api/Manage
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Manage/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Manage
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Manage/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
