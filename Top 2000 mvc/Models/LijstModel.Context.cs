﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Top_2000_mvc.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LijstEntities2 : DbContext
    {
        public LijstEntities2()
            : base("name=LijstEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Artiest> Artiest { get; set; }
        public virtual DbSet<Lijst> Lijst { get; set; }
        public virtual DbSet<Song> Song { get; set; }
    }
}
