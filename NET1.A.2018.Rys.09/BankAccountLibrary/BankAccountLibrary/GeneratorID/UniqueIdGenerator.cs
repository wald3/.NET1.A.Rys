using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountLibrary.IdGenerator
{
    class UniqueIdGenerator : IIdGenerator
    {
        public string GererateId()
        {
            return DateTime.Now.ToString("mssfssfmsmsfmsfm").Substring(0,10);
        }
    }
}
