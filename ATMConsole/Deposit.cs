using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMConsole
{
    class Deposit : TransactionFM
    {
        private readonly string _transactionType;
        public Deposit()
        {
            _transactionType = "Deposit";
        }

        public override string TransactionType
        {
            get { return _transactionType; }
        }

        public TransactionFM PlaceDeposit() 
        { 
            return new Deposit();
        }
         
    }
}
