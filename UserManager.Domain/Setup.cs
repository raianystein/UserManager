using FluentValidation;
using Mediator;
using Microsoft.Extensions.DependencyInjection;
using UserManager.Domain.Entities;
using UserManager.Domain.PipelineBehaviors;
using UserManager.Domain.Validators;

namespace UserManager.Domain;

public static class Setup
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddMediator(c =>
         {
             c.Namespace = null;
             c.ServiceLifetime = ServiceLifetime.Scoped;
         });

        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(ValidatorPipelineBehavior<,>));
        services.AddValidatorsFromAssemblyContaining(typeof(Setup), ServiceLifetime.Transient);
        services.AddAutoMapper(typeof(Setup));
        services.AddSingleton<IValidator<User>, UserValidator>();

        return services;
    }
}