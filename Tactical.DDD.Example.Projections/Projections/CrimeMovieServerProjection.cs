using System.Threading.Tasks;
using Aperture.Core;
using Microsoft.Extensions.Logging;
using Tactical.DDD.EventSourcing.Postgres.Aperture;
using Tactical.DDD.Example.Domain.Events;
using Tactical.DDD.Example.Projections;

namespace Aperture.Example.Projections
{
    public class CrimeMovieServerProjection :
        PostgresProjection,
        IHandle<MovieAddedToCatalogue>
    {
        private readonly ILogger<Worker> _logger;

        public CrimeMovieServerProjection(ITrackOffset offsetTracker, ILogger<Worker> logger) : base(offsetTracker)
        {
            _logger = logger;
            _logger.LogInformation($"Starting {GetType().Name}...");
        }

        public Task HandleAsync(MovieAddedToCatalogue @event)
        {
            if (@event.Genre != Genre.Crime) return Task.CompletedTask;

            _logger.LogInformation($"Saving {@event.Title}.");

            return Task.CompletedTask;
        }
    }
}