﻿
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Model;

public class AppUser : IdentityUser
{
    public string FullName { get; set; }
    public List<Rating> Ratings { get; set; }

}
