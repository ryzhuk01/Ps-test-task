using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using Plumsail.Application.Submissions.Commands.CreateSubmission;
using BuildingBlocks.Cqrs.Behaviors;

namespace Plumsail.Application.Extensions;
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
