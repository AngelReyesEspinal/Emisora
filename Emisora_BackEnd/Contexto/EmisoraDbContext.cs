using Microsoft.EntityFrameworkCore;
using Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contexto
{
    public class EmisoraDbContext : DbContext
    {
        public DbSet<Grabacion> Grabacion { get; set; }
        public DbSet<Transmision> Transmision { get; set; }

        public EmisoraDbContext(DbContextOptions<EmisoraDbContext> options)
            : base(options)
        { }
    }
}
