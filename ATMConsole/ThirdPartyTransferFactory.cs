using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMConsole
{
    class ThirdPartyTransferFactory : TransactionFactory
    {
        public ThirdPartyTransferFactory()
        { 
        
        }
        public override TransactionFM GetTransaction()
        {
            return new ThirdPartyTransfer();
        }
    }
}
