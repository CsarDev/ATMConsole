using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMConsole
{
    class DepositFactory : TransactionFactory
    {
        private Int64 _banckAccountNoFrom;
        private Int64 _banckAccountNoTo;
        private decimal _transactionAmount;

        public DepositFactory(Int64 accountNoFrom, Int64 accountNoTo, decimal transaction_amt)
        {
            _banckAccountNoFrom = accountNoFrom;
            _banckAccountNoTo = accountNoTo;
            _transactionAmount = transaction_amt;
        }
        public override TransactionFM GetTransaction()
        {
            return new Deposit(_banckAccountNoFrom, _banckAccountNoTo, _transactionAmount);
        }
    }
}
