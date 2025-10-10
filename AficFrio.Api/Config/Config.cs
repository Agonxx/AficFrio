using AficFrio.Api.Database.Context;
using AficFrio.Api.Repositories;
using AficFrio.Api.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AficFrio.Api.Config
{
    public static class Config
    {
        public static IServiceCollection SetupDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionStringGlobal = configuration.GetConnectionString("ConexaoDBGlobal");
            var connectionStringRestaurante = configuration.GetConnectionString("ConexaoDBRestaurante");

            services.AddDbContext<DBRestaurante>(options =>
                options.UseSqlServer(connectionStringRestaurante)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .ConfigureWarnings(warnings =>
                    warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));

            return services;
        }

        public static IServiceCollection SetupRepositories(this IServiceCollection services)
        {
            services.AddScoped<UsuarioRestRepository, UsuarioRestRepository>();

            services.AddScoped<TransactionService>();

            return services;
        }
    }
}
