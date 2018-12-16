using System;
using System.Collections.Generic;
using System.Text;
using BankAccountLibrary.Account;

namespace BankAccountLibrary.Repository
{
    public interface IRepository
    {
        void Save(Account.Account account);

        Account.Account GetAccountByNumber(string number);

        void Close(Account.Account account);
    }
}
