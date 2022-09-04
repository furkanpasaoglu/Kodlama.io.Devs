using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Persistence.Contexts;
using Kodlama.io.Devs.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kodlama.io.Devs.Persistence;

/// <summary>
/// Persistence katmanı için servisleri kayıt eder.
/// </summary>
public static class KodlamaioDevsPersistenceServiceRegistration
{
    public static IServiceCollection AddKodlamaioDevsPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("KodlamaioDevsConnectionString")));

        services.AddScoped<IProgrammingLanguageRepository, ProgrammingLanguageRepository>();
        
        return services;
    }
}