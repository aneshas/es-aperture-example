using System;
using System.Threading.Tasks;
using Aperture.Core;
using Microsoft.Extensions.Logging;
using Tactical.DDD.EventSourcing.Postgres.Aperture;
using Tactical.DDD.Example.Domain.Events;
using Tactical.DDD.Example.Projections;

namespace Aperture.Example.Projections
{
    public class SciFiMoviesServerProjection : 
        PostgresProjection, 
        IHandle<MovieAddedToCatalogue>
    {
        private readonly ILogger<Worker> _logger;

        public SciFiMoviesServerProjection(ITrackOffset offsetTracker, ILogger<Worker> logger) : base(offsetTracker)
        {
            _logger = logger;
            _logger.LogInformation($"Starting {GetType().Name}...");
        }

        public Task HandleAsync(MovieAddedToCatalogue @event)
        {
            _logger.LogError(">>>>>>>>>>>>>>>>>>>>>>>> Restarting...");
            throw new NotImplementedException();

            // if (@event.Genre != Genre.SciFi) return Task.CompletedTask;
            //
            // _logger.LogInformation($"Saving {@event.Title}.");
            //
            // return Task.CompletedTask;
        }
    }
}