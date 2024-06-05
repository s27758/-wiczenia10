using Ćwiczenia10.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ćwiczenia10.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountsController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet("{accountId:int}")]
    public async Task<IActionResult> GetAccountById(int accountId)
    {
        var accountDto = await _accountService.GetAccountByIdAsync(accountId);
        if (accountDto == null)
        {
            return NotFound();
        }

        return Ok(accountDto);
    }
}