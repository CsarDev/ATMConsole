using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMConsole
{
    public class ActiveState : BankAccountState
    {
        public override void CheckState(BankAccount account)
        {
            account.changeState(new LockedState());
            account.isLocked = true;
        }

        public override string ShowState()
        {
            return "Account Active";
        }
    }
}
