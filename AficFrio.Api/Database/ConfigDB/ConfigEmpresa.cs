using AficFrio.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AficFrio.Api.Database.ConfigDB
{
    public class ConfigEmpresa : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {


            builder.HasData(new Empresa[]
            {
                new Empresa {
                    Id = 1,
                    Nome = "Dev's Burguer",
                    QRCodeMobile = "Pendente"
                }

            });
        }
    }
}
