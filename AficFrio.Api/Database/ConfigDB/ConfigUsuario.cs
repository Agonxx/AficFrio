using AficFrio.Shared.Enums;
using AficFrio.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AficFrio.Api.Database.ConfigDB
{
    public class ConfigUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasOne<Empresa>()
                .WithMany()
                .HasForeignKey(h => h.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new Usuario[]
            {
                new Usuario {
                    Id = 1,
                    EmpresaId = 1,
                    Username = "User",
                    Email = "admin@admin.com",
                    Senha = "gfse3McKBuFWBrNpAwRVDg==",
                    Role = ERole.User,
                    CadastradoEm = DateTime.Now.AddDays(-6),
                },
                new Usuario {
                    Id = 2,
                    EmpresaId = 1,
                    Username = "Admin",
                    Email = "admin@admin.com",
                    Senha = "gfse3McKBuFWBrNpAwRVDg==",
                    Role = ERole.Admin,
                    CadastradoEm = DateTime.Now.AddDays(-6),
                },
                 new Usuario {
                    Id = 3,
                    EmpresaId = 1,
                    Username = "RafaDev",
                    Email = "admin@admin.com",
                    Senha = "gfse3McKBuFWBrNpAwRVDg==",
                    Role = ERole.Dev,
                    CadastradoEm = DateTime.Now.AddDays(-6),
                }
            });
        }
    }
}
