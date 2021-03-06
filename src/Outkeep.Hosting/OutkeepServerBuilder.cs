﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orleans.Hosting;
using System;
using System.Collections.Generic;
using HostBuilderContext = Microsoft.Extensions.Hosting.HostBuilderContext;

namespace Outkeep.Hosting
{
    internal class OutkeepServerBuilder : IOutkeepServerBuilder
    {
        private readonly List<Action<HostBuilderContext, IOutkeepServerBuilder>> outkeepConfigurators = new List<Action<HostBuilderContext, IOutkeepServerBuilder>>();
        private readonly List<Action<HostBuilderContext, IServiceCollection>> serviceConfigurators = new List<Action<HostBuilderContext, IServiceCollection>>();
        private readonly List<Action<HostBuilderContext, ISiloBuilder>> siloConfigurators = new List<Action<HostBuilderContext, ISiloBuilder>>();

        public OutkeepServerBuilder(IHostBuilder builder)
        {
            // wire up outkeep configuration
            builder.ConfigureServices((context, services) =>
            {
                // outkeep configuration actions will populate service actions below
                foreach (var configure in outkeepConfigurators)
                {
                    configure(context, this);
                }

                // apply all the service configuration actions now
                foreach (var configure in serviceConfigurators)
                {
                    configure(context, services);
                }
            });

            // wire up silo configuration
            builder.UseOrleans((context, silo) =>
            {
                foreach (var configure in siloConfigurators)
                {
                    configure(context, silo);
                }
            });
        }

        public IOutkeepServerBuilder ConfigureOutkeep(Action<HostBuilderContext, IOutkeepServerBuilder> configure)
        {
            outkeepConfigurators.Add(configure);

            return this;
        }

        public IOutkeepServerBuilder ConfigureServices(Action<HostBuilderContext, IServiceCollection> configure)
        {
            serviceConfigurators.Add(configure);

            return this;
        }

        public IOutkeepServerBuilder ConfigureSilo(Action<HostBuilderContext, ISiloBuilder> configure)
        {
            siloConfigurators.Add(configure);

            return this;
        }
    }
}