using Ćwiczenia10.DTO;

namespace Ćwiczenia10.Services;

public interface IAccountService
{
    Task<AccountDto> GetAccountByIdAsync(int accountId);
}
