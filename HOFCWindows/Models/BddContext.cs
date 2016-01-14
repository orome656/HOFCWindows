using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOFCWindows.Models
{
    class BddContext: DbContext
    {
        public DbSet<Actu> Actus { get; set; }
        public DbSet<Calendrier> Calendriers { get; set; }
        public DbSet<Classement> Classements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename=HOFC.db");
        }
    }
}
