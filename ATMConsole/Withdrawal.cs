using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMConsole
{
    class Withdrawal : TransactionFM
    {
        private readonly string _transactionType;
        public Withdrawal()
        {
            _transactionType = "Withdrawal";
        }

        public override string TransactionType
        {
            get { return _transactionType; }
        }

        public TransactionFM MakeWithdrawal() 
        { 
            return new Withdrawal();
        }
         
    }
}
