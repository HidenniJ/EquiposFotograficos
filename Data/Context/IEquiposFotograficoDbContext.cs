using EquiposFotograficos.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EquiposFotograficos.Data.Context
{
    public interface IEquiposFotograficoDbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}