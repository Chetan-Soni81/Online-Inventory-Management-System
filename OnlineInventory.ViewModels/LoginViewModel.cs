﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="* Username is required")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "* Password is required")]
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }
}