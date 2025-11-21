using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Ps.Core.Common.Interfaces;
using Ps.Infrastructure.Persistence;
using Ps.Infrastructure.Repositories;

namespace Ps.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase(configuration["DatabaseName"] ?? string.Empty))
            .AddScoped<IFormSubmissionRepository, FormSubmissionRepository>();
    }
}
