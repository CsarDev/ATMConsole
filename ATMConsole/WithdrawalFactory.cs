using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMConsole
{
    class WithdrawalFactory : TransactionFactory
    {
        public WithdrawalFactory()
        { 
        
        }
        public override TransactionFM GetTransaction()
        {
            return new Withdrawal();
        }
    }
}
