using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Repository.Repository;
using Tutorial.Repository.Request;
using Tutorial.Repository.Response;

namespace Tutorial.Services
{
    public interface IAccountService
    {
        Task<CreateAccountRespone> CreateAccount(CreateAccountRequest request);
        Task<List<GetAccountResponse>> GetAllAccount();
    }
}
