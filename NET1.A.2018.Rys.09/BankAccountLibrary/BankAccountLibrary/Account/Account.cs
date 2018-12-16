using System;

namespace BankAccountLibrary.Account
{
    public abstract class Account
    {
        private double _bonus;
        private string _accountId;
        private AccountOwner.AccountOwner _owner;

        public double Bonus
        {
            get => _bonus;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(nameof(value), " Bonus can`t be less or equal zero!");
                }

                _bonus += value;
            }
        }

        public string AccountId
        {
            get => _accountId;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }
            }
        }


        public Account(string accountId)
        {
            this._accountId = accountId;
        }
    }
}
