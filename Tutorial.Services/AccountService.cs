using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Repository.Entity;
using Tutorial.Repository.Repository;
using Tutorial.Repository.Request;
using Tutorial.Repository.Response;

namespace Tutorial.Services
{
    public class AccountService : IAccountService
    {
        private AccountRepository _accountRepository;
        public AccountService()
        {
            _accountRepository = new AccountRepository();
        }

        public async Task<CreateAccountRespone> CreateAccount(CreateAccountRequest request)
        {
            var account = new Acsount {
             Id = Guid.NewGuid(),
             Username = request.UserName,             
             Password = request.Password,
             Email = request.Email,
             Active = true
            };

             await _accountRepository.CreateAsync(account); // đã lưu vào db rồi

            // trả về reponse

            var response = new CreateAccountRespone
            {
                UserName = account.Username,
                Email = account.Email,
                Active = account.Active
            };

            return response;
        }
    }
}
