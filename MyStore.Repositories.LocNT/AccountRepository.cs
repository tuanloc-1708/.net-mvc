using MyStore.Business.LocNT;
using MyStore.DataAccess.LocNT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Repositories.LocNT
{
    public class AccountRepository : IAccountRepository
    {
        public AccountMember GetAccountById(string accountId)
                => AccountDAO.GetAccountById(accountId);
    }
}

