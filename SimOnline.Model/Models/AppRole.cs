﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimOnline.Model.Models
{
    public class AppRole : IdentityRole
    {
        public AppRole() : base()
        {

        }
        [StringLength(250)]
        public string Description { set; get; }
    }
}
