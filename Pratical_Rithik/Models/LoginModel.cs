using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pratical_Rithik.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter user name")]
        [Display(Name = "UserName")]
        public string name { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [Display(Name = "Password")]
        public string passowrd { get; set; }
    }
}