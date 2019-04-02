using Microsoft.AspNetCore.Identity;
using System;

namespace Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}
