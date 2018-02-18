using System;
using System.Collections.Generic;
using System.Data.Entity;
using WebApplication1.Models;


namespace WebApplication1.DAL
{
    public class CommonContext : DbContext
    {
        public CommonContext() : base("DefaultConnection")
        { 
        }

        public DbSet<Administration>    Administrations { get; set; }
        public DbSet<Section>           Sections        { get; set; }
        public DbSet<Group>             Groups          { get; set; }
        public DbSet<Subgroup>          Subgroups       { get; set; }
        public DbSet<Employee>          Employees       { get; set; }
    }
}