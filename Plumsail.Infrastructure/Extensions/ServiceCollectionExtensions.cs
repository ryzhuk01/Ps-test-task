using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Plumsail.Core.Common.Interfaces;
using Plumsail.Infrastructure.Persistence;
using Plumsail.Infrastructure.Repositories;

namespace Plumsail.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase(configuration["DatabaseName"] ?? string.Empty))
            .AddScoped<IFormSubmissionRepository, FormSubmissionRepository>();
    }
}
