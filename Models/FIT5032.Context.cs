﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FIT5032Entities : DbContext
    {
        public FIT5032Entities()
            : base("name=FIT5032Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdministratorSet> AdministratorSets { get; set; }
        public virtual DbSet<AppliancesSet> AppliancesSets { get; set; }
        public virtual DbSet<CredentialSet> CredentialSets { get; set; }
        public virtual DbSet<OrderSet> OrderSets { get; set; }
        public virtual DbSet<UserSet> UserSets { get; set; }
    }
}
