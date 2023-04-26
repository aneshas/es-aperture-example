using Aperture.Core;
using Bank24.ProjectionWorker;
using Bank24.ProjectionWorker.Projections;
using Tactical.DDD.EventSourcing.Postgres.Aperture;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();

        services.AddSingleton<IProjectEvents, AllAccountsProjection>();
        services.AddSingleton<IProjectEvents, FooProjection>();

        services.AddPostgresAperture(
            "Host=localhost;Database=your-db;Username=your-username",
            new PullEventStream.Config
            {
                PullInterval = TimeSpan.FromMilliseconds(200),
                BatchSize = 500
            });

        services.AddAperture();
    })
    .Build();

host.Run();