using Aperture.Core;
using Bank24.Core.AccountAggregate;
using Tactical.DDD.EventSourcing.Postgres.Aperture;

namespace Bank24.ProjectionWorker.Projections;

public class AllAccountsProjection : PostgresProjection, IHandle<AccountProvisioned>
{
    public AllAccountsProjection(ITrackOffset offsetTracker) : base(offsetTracker)
    {
    }
    
    public Task HandleAsync(AccountProvisioned @event)
    {
        Console.WriteLine($"{nameof(AllAccountsProjection)} -> New account provisioned for: {@event.AccountHolder}");
        
        return Task.CompletedTask;
    }
}