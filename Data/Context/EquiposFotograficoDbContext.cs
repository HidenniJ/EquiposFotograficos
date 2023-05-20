using Microsoft.EntityFrameworkCore; // Esta declaración es para utilizar las clases y métodos del Entity Framework Core.
using EquiposFotograficos.Data.Entities; //Esta declaración es donde se encuentran definidas las entidades del modelo de datos.

namespace EquiposFotograficos.Data.Context
{
    public class EquiposFotograficoDbContext : DbContext //Esta línea declara la clase EquiposFotograficoDbContext y la hace heredar de la clase DbContext
, IEquiposFotograficoDbContext
    {
        private readonly IConfiguration config;

        public EquiposFotograficoDbContext(IConfiguration config) // Este es el constructor de la clase
        {
            this.config = config;
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: config.GetConnectionString(name: "MSSQL")); // En esta línea se configura el proveedor de base de datos y la cadena de conexión
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
