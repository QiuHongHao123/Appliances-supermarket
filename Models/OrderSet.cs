//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FIT5032_assignment.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderSet
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string CurrentLocation { get; set; }
        public int UserId { get; set; }
        public int AppliancesId { get; set; }
    
        public virtual AppliancesSet AppliancesSet { get; set; }
        public virtual UserSet UserSet { get; set; }
    }
}