using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC.Models
{
    public class PersonContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }

        public PersonContext() : base("con1") { }

    }
}