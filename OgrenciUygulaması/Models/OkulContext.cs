using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OgrenciUygulaması.Models
{
    public class OkulContext : DbContext
    {
        public OkulContext() : base("OkulContext") { }

        public DbSet<tFakulte> Fakulteler { get; set; }
        public DbSet<tBolum> Bolumler { get; set; }
        public DbSet<tOgrenci> Ogrenciler { get; set; }
        public DbSet<tDers> Dersler { get; set; }
        public DbSet<tOgrenciDers> OgrenciDersler { get; set; }
    }
}