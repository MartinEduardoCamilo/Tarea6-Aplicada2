using Microsoft.EntityFrameworkCore;
using SuplidoresBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuplidoresBlazor.DAL
{
    public class Contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=DATA\Suplider.db");
        }

        public DbSet<Ordenes> Ordenes { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Suplidores> Suplidores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                productoId = 1,
                descripcion = "Cacao",
                costo = 100,
                inventario = 0
            });

            modelBuilder.Entity<Suplidores>().HasData(new Suplidores
            {
                suplidorId = 1,
                nombre = "Rizek"
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                productoId = 2,
                descripcion = "Chocolate",
                costo = 100,
                inventario = 0
            });

            modelBuilder.Entity<Suplidores>().HasData(new Suplidores
            {
                suplidorId = 2,
                nombre = "Supremo"
            });

        }
    }
}
