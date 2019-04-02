using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class TokenController
    {

        [Route("api/Token"]
        public class TokenController : Controller
        {
            private IConfiguration _config;

            public TokenController(IConfiguration config)
            {
                _config = config;
            }

            [AllowAnonymous]

            [HttpPost]

            public dynamic Post([FromBody]LoginViewModel login)
            {

            }
        }
    }
}
