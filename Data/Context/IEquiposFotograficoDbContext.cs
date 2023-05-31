using EquiposFotograficos.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EquiposFotograficos.Data.Context
{
    public interface IEquiposFotograficoDbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}