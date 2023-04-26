using Bank24.Core.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bank24.Api.Controllers;

[ApiController]
[Route("accounts")]
public class AccountsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ProvisionedAccount> Provision(AccountToProvision accountToProvision)
    {
        var result = await _mediator.Send(accountToProvision);

        return new ProvisionedAccount(result.AccountId);
    }
}