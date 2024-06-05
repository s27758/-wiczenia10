using Ćwiczenia10.Data;
using Ćwiczenia10.DTO;
using Microsoft.EntityFrameworkCore;

namespace Ćwiczenia10.Services;

public class AccountService : IAccountService
{
    private readonly ApplicationDbContext _context;

    public AccountService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<AccountDto> GetAccountByIdAsync(int accountId)
    {
        var account = await _context.Accounts
            .Include(a => a.Role)
            .Include(a => a.ShoppingCarts)
            .ThenInclude(sc => sc.Product)
            .FirstOrDefaultAsync(a => a.AccountId == accountId);

        if (account == null)
        {
            return null;
        }

        var accountDto = new AccountDto
        {
            FirstName = account.FirstName,
            LastName = account.LastName,
            Email = account.Email,
            Phone = account.Phone,
            Role = account.Role.Name,
            Cart = account.ShoppingCarts.Select(sc => new ShoppingCartDto
            {
                ProductId = sc.ProductId,
                ProductName = sc.Product.Name,
                Amount = sc.Amount
            }).ToList()
        };

        return accountDto;
    }
}