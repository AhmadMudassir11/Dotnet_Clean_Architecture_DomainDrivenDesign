using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Common.Behaviors;
using BuberDinner.Application.Services.Authentication.Commands;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Application.Services.Authentication.Queries;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuberDinner.Application
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            #region CRQS
            // CQRS Implementation
            services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
            services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
            #endregion

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateBehavior<,>));

            services.AddMediatR((cfg => cfg.RegisterServicesFromAssembly(typeof(DependancyInjection).Assembly)));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();

            return services;
        }
    }
}
