using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SerwisSamochodowy.Models
{
    public class SerwisContext : DbContext
    {
        public SerwisContext(DbContextOptions<SerwisContext> options): base(options) { }
        public DbSet<Klient> Klients { get; set; }
        public DbSet<Mechanik> Mechaniks { get; set; }
        public DbSet<Samochod> Samochods { get; set; }
        public DbSet<Zlecenie> Zlecenies { get; set; }
    }
}
