//using System;
using System.Collections.Generic;
using Auth.Demo;
using Microsoft.AspNetCore.Authorization;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIJWT.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class NameController : ControllerBase
    {   //For JWT Authentication
        //private readonly IJWTAuthenticationManager jWTAuthenticationManager; 
        //public NameController(IJWTAuthenticationManager jWTAuthenticationManager)
        //{
        //    this.jWTAuthenticationManager = jWTAuthenticationManager;
        //}
        //
        //For Custom Authentication
        private readonly ICustomAuthenticationManager customAuthenticationManager; 
        public NameController(ICustomAuthenticationManager customAuthenticationManager)
        {
            this.customAuthenticationManager = customAuthenticationManager;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            //For JWT Authentication
            //var token = jWTAuthenticationManager.Authenticate(userCred.Username, userCred.Password);

            //For Custom Authentication
            var token = customAuthenticationManager.Authenticate(userCred.Username, userCred.Password);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
         

        // GET: api/Name
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Name/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Name
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Name/5
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
