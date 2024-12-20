﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PeakFit.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Core.Services
{
    // This service runs in the background and deletes events with expired dates
    public class ExpiredEventCleanupService(IServiceProvider serviceProvider) : BackgroundService
    {
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var myService = scope.ServiceProvider.GetRequiredService<IDeleteEventWithExpiredDateService>();
                    await myService.DeleteExpiredEventsAsync();
                }

                // Run every day 
                await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
            }
        }
    }
}
