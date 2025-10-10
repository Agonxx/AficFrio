using AficFrio.Api.Database.ConfigDB;
using AficFrio.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace AficFrio.Api.Database.Context
{
    public class DBRestaurante : DbContext
    {
        public DBRestaurante(DbContextOptions<DBRestaurante> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConfigEmpresa());
            modelBuilder.ApplyConfiguration(new ConfigUsuario());
        }
    }
}
