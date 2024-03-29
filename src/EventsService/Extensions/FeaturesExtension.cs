﻿using EventsService.Behaviors;
using FluentValidation;
using MediatR;
using System.Reflection;

namespace EventsService.Extensions;

public static class FeaturesExtension
{
    public static IServiceCollection AddFeatures(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        /*
        services.AddScoped<IValidator<AddEventCommand>, AddEventCommandValidator>();
        services.AddScoped<IValidator<GetEventsQuery>, GetEventsQueryValidator>();
        services.AddScoped<IValidator<UpdateEventCommand>, UpdateEventCommandValidator>();
        services.AddScoped<IValidator<IssueTicketToUserCommand>, IssueTicketToUserCommandValidator>();
        */

        return services;
    }
}
