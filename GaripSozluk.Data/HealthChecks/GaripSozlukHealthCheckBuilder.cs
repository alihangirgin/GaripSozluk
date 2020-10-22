using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
namespace GaripSozluk.Data.HealthChecks
{
    public static class GaripSozlukHealthCheckBuilder
    {
        public static IHealthChecksBuilder AddGaripSozlukHealthChecks(this IServiceCollection services)
        {
            var builder = services.AddHealthChecks();

            builder.AddCheck<GaripSozlukDbContextHealthCheck>("GaripSozlukDbContextCheck");

            //add your custom health checks here
            //builder.AddCheck<MyCustomHealthCheck>("my health check");

            return builder;
        }
    }
}
