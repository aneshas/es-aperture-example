using Tactical.DDD;

namespace Bank24.Core.AccountAggregate;

public record AccountProvisioned : DomainEvent
{
    public string AccountId { get; private set; }
    
    public string AccountHolder { get; private set; }
    
    public AccountProvisioned(DateTime CreatedAt, string accountHolder, string accountId) : base(CreatedAt)
    {
        AccountHolder = accountHolder;
        AccountId = accountId;
    }
}