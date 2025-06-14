﻿using System;
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
        public AccountService( AccountRepository accountRepository)
        {
            _accountRepository= accountRepository;
        }

        public async Task<CreateAccountRespone> CreateAccount(CreateAccountRequest request)
        {
            var account = new Account {
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

        public  async Task<List<GetAccountResponse>> GetAllAccount()

        {
            var accounts = await _accountRepository.GetAllAsync();
            List<GetAccountResponse> accountResponses = new List<GetAccountResponse>();
            // foreach (var account in accounts)
            //{
            //    GetAccountResponse accountResponse = new GetAccountResponse
            //    {
            //        Id = account.Id,
            //        UserName = account.Username,
            //        Email = account.Email,
            //        Active = account.Active
            //    };
            //    accountResponses.Add(accountResponse);
            //}
            //    return accountResponses;
            accountResponses = accounts.Select(account => new GetAccountResponse
            {
                Id = account.Id,
                UserName = account.Username,
                Email = account.Email,
                Active = account.Active
            }).ToList();
            return accountResponses;
        }
    }
}
