﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace djelatniciZadaci.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class djelatniciZadaciEntities : DbContext
    {
        public djelatniciZadaciEntities()
            : base("name=djelatniciZadaciEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Djelatnici> Djelatnici { get; set; }
        public virtual DbSet<RadniZadaci> RadniZadaci { get; set; }
    }
}
