using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FIT5032_assignment.Models
{
    public class FormViewModel
    {
    }
    public class RegisterView {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
  
        public string Email { get; set; }
        public string Address { get; set; }
    } 
}