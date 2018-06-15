﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamePackman.Models
{
    public class UserData
    {
        [Required]
        [Display(Name = "Login")]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required, DataType(DataType.Password)]
        [Display(Name = "Password Repeat")]
        public string PasswordRepeat { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
