using FoodFlow.Modules.Movements.Business.Abstractions;
using FoodFlow.Modules.Movements.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodFlow.Modules.Movements.Persistence;

public static class LayerRegistration
{
    public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MovementsDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped(typeof(IMovementsRepository<>), typeof(MovementsRepository<>));

        return services;
    }
}
