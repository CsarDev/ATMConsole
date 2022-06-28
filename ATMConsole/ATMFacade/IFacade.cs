using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMConsole
{
    public interface IFacade
    {
        void CheckCardNoPassword();
        void CheckBalance();
        void PlaceDeposit();
        void MakeWithdrawal();
        void PerformThirdPartyTransfer(VMThirdPartyTransfer vMThirdPartyTransfer);
        void ViewTransaction();
    }
}
