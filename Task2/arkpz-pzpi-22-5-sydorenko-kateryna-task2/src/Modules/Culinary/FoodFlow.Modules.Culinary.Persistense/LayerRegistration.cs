using FoodFlow.Modules.Culinary.Business.Abstractions;
using FoodFlow.Modules.Culinary.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodFlow.Modules.Culinary.Persistence;

public static class LayerRegistration
{
    public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CulinaryDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped(typeof(ICulinaryRepository<>), typeof(CulinaryRepository<>));

        return services;
    }
}
