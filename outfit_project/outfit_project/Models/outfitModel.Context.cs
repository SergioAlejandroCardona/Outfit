﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace outfit_project.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class outfitEntities1 : DbContext
    {
        public outfitEntities1()
            : base("name=outfitEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<appointment> appointment { get; set; }
        public virtual DbSet<customer> customer { get; set; }
        public virtual DbSet<product> product { get; set; }
        public virtual DbSet<reservation> reservation { get; set; }
        public virtual DbSet<sale> sale { get; set; }
        public virtual DbSet<seller> seller { get; set; }
        public virtual DbSet<supplier> supplier { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
