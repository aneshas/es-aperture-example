using Tactical.DDD;

namespace Bank24.Core.AccountAggregate;

public class Account : AggregateRoot<AccountId>
{
    public Account(IEnumerable<DomainEvent> events) : base(events)
    {
    }

    private Account()
    {
    }
    
    public static Account FromHolder(AccountId id, string holder)
    {
        var acc = new Account();
        
        acc.Apply(new AccountProvisioned(DateTime.Now, holder, id));

        return acc;
    }

    public void On(AccountProvisioned @event)
    {
        Id = AccountId.Parse(@event.AccountId);
    }
}