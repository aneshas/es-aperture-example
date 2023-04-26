namespace Bank24.Core.AccountAggregate;

public interface IAccountRepo
{
    Task SaveAsync(Account account);
}