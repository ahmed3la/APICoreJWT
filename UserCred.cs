using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJWT
{
    //public IActionResult Authenticate([FromBody] UserCred userCred)
    //{
    //    return Ok();
    //}

    public class UserCred
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
