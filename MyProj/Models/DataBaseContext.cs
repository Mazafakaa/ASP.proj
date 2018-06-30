using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MyProj.Models
{
    public class DataBaseContext: DbContext
    {
        public DataBaseContext() : base("socdb")
        {

        }
        public  DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Participiant> Participiants { get; set; }
        public DbSet<_Message> Messages { get; set; }
        public DbSet<Event_Mesaage> Event_Mesaages { get; set; }
    }
}