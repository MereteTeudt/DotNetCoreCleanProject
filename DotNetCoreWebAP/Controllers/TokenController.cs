﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.WebAPI.Controllers
{
    public class TokenController
    {

        [Route("api/Token")]
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
                IActionResult response = Unauthorized();

                var user = Authenticate(login);

                if (user != null)
                {
                    var tokenString = BuildToken(user);

                    response = Ok(new { token = tokenString });
                }
                return response;
            }

            private string BuildToken(UserViewModel user)
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            private UserViewModel Authenticate(LoginViewModel login)
            {
                UserViewModel user = null;

                if (login.username == "pablo" && login.password == "secret")
                {
                    user = new UserViewModel { nameof = "Pablo" };
                }
                return user;
            }
        }
    }
}
