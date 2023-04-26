using Tactical.DDD;

namespace Bank24.Core.AccountAggregate;

public sealed record AccountId : EntityId
{
    private Guid _guid;

    public AccountId() =>
        _guid = Guid.NewGuid();

    public static AccountId Parse(string id)
    {
        var accountId = new AccountId();

        accountId._guid = Guid.Parse(accountId);

        return accountId;
    } 

    public override string ToString() => _guid.ToString();
}