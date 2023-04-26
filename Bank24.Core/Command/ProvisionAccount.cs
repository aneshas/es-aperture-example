using Bank24.Core.AccountAggregate;
using MediatR;

namespace Bank24.Core.Command;

public record AccountToProvision(string AccountHolder) : IRequest<ProvisionedAccount>;

public record ProvisionedAccount(string AccountId);

public class ProvisionAccount : IRequestHandler<AccountToProvision, ProvisionedAccount>
{
    private readonly IAccountRepo _repo;

    public ProvisionAccount(IAccountRepo repo)
    {
        _repo = repo;
    }

    public async Task<ProvisionedAccount> Handle(AccountToProvision request, CancellationToken cancellationToken)
    {
        var id = new AccountId();

        var acc = Account.FromHolder(id, request.AccountHolder);

        await _repo.SaveAsync(acc);

        return new ProvisionedAccount(acc.Id);
    }
}