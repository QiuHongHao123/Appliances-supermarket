using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
/*
 * author Qiu
 * The View models to generate view and transfor the data
 *  
 */
namespace FIT5032_assignment.Models
{
    public class ShowViewModel
    {
     
    }
    public class ApplianceShowViewModel {
        [Key]
        public int id { get; set; }
        public string applianceName { get; set; }
        public string imgUrl { get; set; }
        public float price { get; set; }
        public int amount { get; set; }
        public string describe { get; set; }
    }


}
