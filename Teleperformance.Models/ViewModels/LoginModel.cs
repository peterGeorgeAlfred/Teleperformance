using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Teleperformance.Models.ViewModels
{
  public  class LoginModel
    {
        [Required]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please Enter Your Password")]
        public string Password { get; set; }
    }
}
