using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMConsole
{
    public class LockedState : BankAccountState
    {
        public override void CheckState(BankAccount account)
        {
            account.changeState(new ActiveState());
            account.isLocked = false;
        }

        public override string ShowState()
        {
            return "Locked Account";
        }
    }
}
