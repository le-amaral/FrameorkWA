using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FrameorkWA.Models;

namespace FrameorkWA.Data
{
    // Implemente a lógica do seu Banco de Dados
    public class FrameorkWAContext : DbContext
    {
        public FrameorkWAContext(DbContextOptions<FrameorkWAContext> options)
            : base(options)
        {
        }

        public DbSet<FrameorkWA.Models.Titular> Titular { get; set; } = default!;
        public DbSet<FrameorkWA.Models.Descendentes> Descendentes { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Titular>().ToTable("Titular");
            modelBuilder.Entity<Descendentes>().ToTable("Descendentes");
        }
    }
}