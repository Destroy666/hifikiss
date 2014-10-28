using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using KissHiFi.Models;

namespace KissHiFi.DAL
{
    public class KissHifiContext : DbContext
    {
        public DbSet<Hirek> Hireks { get; set; }
        public DbSet<Bemutatkozas> Bemutatkozases { get; set; }
        public DbSet<Szolgaltatas> Szolgaltatases { get; set; }
        public DbSet<TermekKategoria> TermekKategorias { get; set; }
        public DbSet<TermekMarka> TermekMarkas { get; set; }
        public DbSet<TermekAdatlap> TermekAdatlaps { get; set; }
        public DbSet<Kepek> Kepeks { get; set; }
        public DbSet<Elerhetoseg> Elerhetosegs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}