using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMConsole
{
    public class ATMFacade : IFacade
    {
        private AuthenticationSystem authentication = new AuthenticationSystem();
        private ATMSystem atm = new ATMSystem();
        private BankAccountSystem bankAccount;

        private BankAccount bankAccountSelected;

        public ATMFacade()
        {
            Initialization();
        }

        public void Initialization()
        {
            bankAccount = new BankAccountSystem(atm);
        }

        public void CheckBalance()
        {
            bankAccount.CheckBalance(bankAccountSelected);   
        }

        public void CheckCardNoPassword()
        {
            bankAccountSelected = authentication.CheckCardNoPassword(bankAccount.AccountList);
        }

        public void MakeWithdrawal()
        {
            bankAccount.MakeWithdrawal(bankAccountSelected);
        }

        public void PerformThirdPartyTransfer(VMThirdPartyTransfer vMThirdPartyTransfer)
        {
            bankAccount.PerformThirdPartyTransfer(bankAccountSelected, vMThirdPartyTransfer);
        }

        public void PlaceDeposit()
        {
            bankAccount.PlaceDeposit(bankAccountSelected);
        }

        public void ViewTransaction()
        {
            atm.ViewTransaction(bankAccountSelected);
        }
    }
}
