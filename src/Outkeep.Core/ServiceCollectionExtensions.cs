﻿using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Utility extensions for <see cref="IServiceCollection"/> instances.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds <typeparamref name="T"/> as an <see cref="IHostedService"/> to the <see cref="IServiceCollection"/> if it is not yet present.
        /// </summary>
        public static IServiceCollection TryAddHostedService<T>(this IServiceCollection services) where T : class, IHostedService
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            if (!services.Any(x => x.ServiceType == typeof(IHostedService) && x.ImplementationType == typeof(T)))
            {
                services.AddHostedService<T>();
            }

            return services;
        }
    }
}