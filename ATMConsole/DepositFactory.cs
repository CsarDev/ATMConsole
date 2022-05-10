using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMConsole
{
    class DepositFactory : TransactionFactory
    {
        public DepositFactory()
        { 
        
        }
        public override TransactionFM GetTransaction()
        {
            return new Deposit();
        }
    }
}
