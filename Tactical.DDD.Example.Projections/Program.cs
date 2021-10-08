using System;
using Aperture.Core;
using Aperture.Example.Projections;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tactical.DDD.EventSourcing.Postgres;
using Tactical.DDD.EventSourcing.Postgres.Aperture;

namespace Tactical.DDD.Example.Projections
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddScoped<IProjectEvents, CrimeMovieServerProjection>();
                    services.AddScoped<IProjectEvents, SciFiMoviesServerProjection>();

                    services.AddPostgresEventStore("");
                    services.AddPostgresEventStream();
                    services.AddPostgresAperture(
                        new PullEventStream.Config
                        {
                            PullInterval = TimeSpan.FromMilliseconds(200),
                            BatchSize = 500
                        });

                    services.AddHostedService<Worker>();
                });
    }
}