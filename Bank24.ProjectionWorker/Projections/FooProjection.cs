using Aperture.Core;
using Bank24.Core.AccountAggregate;

namespace Bank24.ProjectionWorker.Projections;

public class FooProjection : Projection, IHandle<AccountProvisioned>
{
    public Task HandleAsync(AccountProvisioned @event)
    {
        Console.WriteLine($"{nameof(FooProjection)} -> New account provisioned for: {@event.AccountHolder}");
        
        return Task.CompletedTask;
    }
}