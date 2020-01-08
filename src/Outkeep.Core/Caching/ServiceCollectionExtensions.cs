﻿using Microsoft.Extensions.DependencyInjection;
using System;

namespace Outkeep.Core.Caching
{
    /// <summary>
    /// Extensions for adding <see cref="CacheDirector"/> to <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCacheDirector(this IServiceCollection services)
        {
            return services.AddCacheDirector(options =>
            {
            });
        }

        /// <summary>
        /// Adds a <see cref="CacheDirector"/> to the <see cref="IServiceCollection"/> as an <see cref="ICacheDirector"/>.
        /// </summary>
        public static IServiceCollection AddCacheDirector(this IServiceCollection services, Action<CacheDirectorOptions> configure)
        {
            return services
                .AddSingleton<ICacheDirector, CacheDirector>()
                .AddOptions<CacheDirectorOptions>()
                .Configure(configure)
                .ValidateDataAnnotations()
                .Services;
        }
    }
}