using Kwik.DTO;
using Microsoft.AspNetCore.Mvc;
using KwikCase.Services;

namespace Kwik.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountBL;

        public AccountController(ILogger<AccountController> logger, IAccountService accountBL)
        {
            _logger = logger;
            _accountBL = accountBL;
        }


        [HttpGet("Accounts")]
        public IActionResult GetAccounts()
        {
            List<AccountDTO> accounts = _accountBL.GetAccounts();
            return accounts.Count() != 0 ? Ok(accounts) : NotFound();
        }

        [HttpGet("Accounts/{id}")]
        public IActionResult GetAccountData(string id)
        {
            var accountData = _accountBL.GetAccount(id);
            return accountData != null ? Ok(accountData) : NotFound();
        }

        [HttpPost("Accounts")]
        public IActionResult CreateAccount(AccountDTO acc)
        {

            return Ok(_accountBL.CreateAccount(acc));
        }

        [HttpDelete("Accounts/{id}")]
        public IActionResult DeleteAccount(string id)
        {
            return _accountBL.DeleteAccount(id) == true ? Ok(true) : BadRequest();
        }

        [HttpPut("Accounts/{id}")]
        public IActionResult UpdateAccountData(AccountDTO acc)
        {
            return Ok(_accountBL.UpdateAccount(acc));
        }
    }
}
