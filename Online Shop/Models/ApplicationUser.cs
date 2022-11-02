﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shop.Models
{
    public class ApplicationUser :IdentityUser
    {
        public String  FirstName { get; set; }
        public String LastName { get; set; }
    }
}
