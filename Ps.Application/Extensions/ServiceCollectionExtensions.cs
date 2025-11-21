using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using Ps.Application.Submissions.Commands.CreateSubmission;
using BuildingBlocks.Cqrs.Behaviors;

namespace Ps.Application.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services
            .AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            }).AddValidatorsFromAssemblyContaining<CreateSubmissionCommandValidator>();
    }
}
