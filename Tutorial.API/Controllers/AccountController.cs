using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial.Repository.Request;
using Tutorial.Repository.Response;
using Tutorial.Services;

namespace Tutorial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<CreateAccountRespone> Create(CreateAccountRequest request)
        {
            return  await _accountService.CreateAccount(request);  
        }



    }
}
