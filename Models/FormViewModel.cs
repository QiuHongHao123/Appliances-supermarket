using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FIT5032_assignment.Models
{
    public class FormViewModel
    {
    }
    public class RegisterView {
        [Required]
        public string Name { get; set; }
        public string Gender { get; set; }
        [Range(18,80)]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }

    public class Login { 
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    public class ResetPasswordView{
        
       
        [Key]
        public int id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string verifyCode{ get; set; }
    }
}