using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesSearchAsp.Models
{
    public class AppUser : IdentityUser
    {
        public string Image { get; set; }
        public string AboutMe { get; set; }
        public DateTime Birthday { get; set; }
    }
}
