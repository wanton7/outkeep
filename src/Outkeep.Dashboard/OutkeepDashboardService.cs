﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Outkeep.Dashboard.Data;
using Outkeep.Dashboard.Properties;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Outkeep.Dashboard
{
    internal class OutkeepDashboardService : IHostedService
    {
        private readonly ILogger _logger;
        private readonly IHost _host;

        public OutkeepDashboardService(ILogger<OutkeepDashboardService> logger, IOptions<OutkeepDashboardOptions> dashboardOptions)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            if (dashboardOptions?.Value is null) throw new ArgumentNullException(nameof(dashboardOptions));

            _host = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(web =>
                {
                    web.UseStaticWebAssets();

                    web.ConfigureServices(services =>
                    {
                        services.AddRazorPages();
                        services.AddServerSideBlazor();
                        services.AddSingleton<WeatherForecastService>();
                    });

                    web.Configure((context, app) =>
                    {
                        var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();

                        if (env.IsDevelopment())
                        {
                            app.UseDeveloperExceptionPage();
                        }
                        else
                        {
                            app.UseExceptionHandler("/Error");

                            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                            app.UseHsts();
                        }

                        app.UseHttpsRedirection();
                        app.UseStaticFiles();

                        app.UseRouting();

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapBlazorHub();
                            endpoints.MapFallbackToPage("/_Host");
                        });
                    });

                    web.UseUrls(dashboardOptions.Value.Url.ToString());
                })
                .Build();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation(Resources.Log_StartingOutkeepDashboard);

            await _host.StartAsync(cancellationToken).ConfigureAwait(false);

            _logger.LogInformation(Resources.Log_StartedOutkeepDashboard);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation(Resources.Log_StoppingOutkeepDashboard);

            await _host.StopAsync(cancellationToken).ConfigureAwait(false);

            _logger.LogInformation(Resources.Log_StoppedOutkeepDashboard);
        }
    }
}