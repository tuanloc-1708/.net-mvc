using MyStore.Business.LocNT;
using MyStore.Repositories.LocNT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services.LocNT
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository iAccountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            iAccountRepository = accountRepository;
        }

        public AccountMember GetAccountByEmail(string accountEmail)
        {
            return iAccountRepository.GetAccountByEmail(accountEmail);
        }
    }
}
