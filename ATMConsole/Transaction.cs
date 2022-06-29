using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMConsole
{
    public abstract class Transaction
    {
        public abstract int TransactionId { get; }

        public abstract Int64 BankAccountNoFrom { get; set; }

        public abstract Int64 BankAccountNoTo { get; set; }

        public abstract TransactionType TransactionType { get; }

        public abstract decimal TransactionAmount { get; set; }

        public abstract DateTime TransactionDate { get; set; }

    }

    public enum TransactionType
    {
        Deposit,
        Withdrawal,
        ThirdPartyTransfer
    }

}
