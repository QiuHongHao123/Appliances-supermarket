using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT5032_assignment.Models
{
    public class ShowViewModel
    {
     
    }
    public class ApplienceShowViewModel {
        [Key]
        public int id { get; set; }
        public string applienceName { get; set; }
        public string imgUrl { get; set; }
        public float price { get; set; }
        public int amount { get; set; }
        public string describe { get; set; }
    }
    
}
