﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartFarm.Models
{
    public class RegisterViewModel
    {
        [Required()]
        public string UserName { get; set; }
        [Required()]
        public string Password { get; set; }
        [Required()]
        public string RePassword { get; set; }
        [Required()]
        public string FullName { get; set; }
        [Required()]
        public string Email { get; set; }
    }
}