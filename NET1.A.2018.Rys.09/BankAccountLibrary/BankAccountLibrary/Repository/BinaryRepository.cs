using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccountLibrary.Repository
{
    public class ListRepository : IRepository
    {
        private List<Account.Account> _accounts;

        public ListRepository() => _accounts = new List<Account.Account>();

        public void Save(Account.Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account), "can't be equal to null!");
            }
            else if (_accounts.Contains(account))
            {
                throw new ArgumentException(nameof(account), "is already in the repository!");
            }

            _accounts.Add(account);
        }

        public void Close(Account.Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account), "can't be equal to null!");
            }
            else if (!_accounts.Contains(account))
            {
                throw new ArgumentException(nameof(account), "not in the repository!");
            }

            _accounts.Remove(account);
        }

        public Account.Account GetAccountByNumber(string accountId)
        {
            if (string.IsNullOrEmpty(accountId))
            {
                throw new ArgumentException(nameof(accountId), "can't be equal to null or empty!");
            }

            return _accounts.FirstOrDefault(temp => temp.AccountId == accountId);
        }
    }
}
