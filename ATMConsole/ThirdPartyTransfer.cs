using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMConsole
{
    class ThirdPartyTransfer : TransactionFM
    {
        private readonly string _transactionType;
        public ThirdPartyTransfer()
        {
            _transactionType = "ThirdPartyTransfer";
        }

        public override string TransactionType
        {
            get { return _transactionType; }
        }

        public TransactionFM PerformThirdPartyTransfer() 
        { 
            return new ThirdPartyTransfer();
        }
         
    }
}
