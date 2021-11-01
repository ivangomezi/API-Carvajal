using ApiVuelos.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVuelos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Vuelos> Vuelos { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<SP_Vuelos> SP_Vuelos { get; set; }
    }
}
