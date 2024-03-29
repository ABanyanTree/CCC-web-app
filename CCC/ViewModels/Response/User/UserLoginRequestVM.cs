﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.UI.ViewModels
{
    public class UserLoginRequestVM
    {
        [Required(ErrorMessage = "Please enter LoginId")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }
        public string Salt { get; set; }
        public string ExistingPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string UserId { get; set; }
    }
}
