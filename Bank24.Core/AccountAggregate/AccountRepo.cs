using Tactical.DDD.EventSourcing;

namespace Bank24.Core.AccountAggregate;

public class AccountRepo : IAccountRepo
{
    private readonly IEventStore _eventStore;

    public AccountRepo(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }

    public async Task SaveAsync(Account account)
    {
        await _eventStore.SaveEventsAsync(
            nameof(Account),
            account.Id,
            account.Version,
            account.DomainEvents,
            new Dictionary<string, string>());
    }
}