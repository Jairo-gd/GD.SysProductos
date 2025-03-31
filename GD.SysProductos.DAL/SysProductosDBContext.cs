using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GD.SysProductos.EN;

namespace GD.SysProductos.DAL
{
        public class SysProductosDBContext : DbContext
        {
            public SysProductosDBContext(DbContextOptions<SysProductosDBContext> options) : base(options)
            {

            }
            public DbSet<Productos> Productos{ get; set; }
            public DbSet<Proveedor> Proveedores{ get; set; }
            public DbSet<Compra> Compras { get; set; }
            public DbSet<DetalleCompra> DetalleCompras { get; set; }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<DetalleCompra>()
                .HasOne(d => d.Compra)
                .WithMany(c => c.DetalleCompras)
                .HasForeignKey(d => d.IdCompra);

                base.OnModelCreating(modelBuilder);
            }

        }
}
