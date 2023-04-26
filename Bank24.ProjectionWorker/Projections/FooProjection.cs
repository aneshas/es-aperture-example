using Aperture.Core;
using Bank24.Core.AccountAggregate;
using Tactical.DDD.EventSourcing.Postgres.Aperture;

namespace Bank24.ProjectionWorker.Projections;

public class FooProjection : PostgresProjection, IHandle<AccountProvisioned>
{
    public FooProjection(ITrackOffset offsetTracker) : base(offsetTracker)
    {
    }
    
    public Task HandleAsync(AccountProvisioned @event)
    {
        Console.WriteLine($"{nameof(FooProjection)} -> New account provisioned for: {@event.AccountHolder}");
        
        return Task.CompletedTask;
    }
}