using System.Reflection;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Rules;
using Kodlama.io.Devs.Application.Features.Users.Rules;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Rules;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Kodlama.io.Devs.Application;

/// <summary>
/// Application Katmanı için servisleri kayıt eder.
/// </summary>
public static class KodlamaioDevsApplicationServiceRegistration
{
    public static IServiceCollection AddKodlamaioDevsApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddScoped<ProgrammingLanguageBusinessRules>();
        services.AddScoped<ProgrammingTechnologyBusinessRules>();
        services.AddScoped<UserBusinessRules>();
        services.AddScoped<UserSocialMediaAddressBusinessRules>();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

        return services;
    }
}