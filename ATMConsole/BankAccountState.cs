using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMConsole
{
    public abstract class BankAccountState
    {
        public abstract void CheckState(BankAccount account);
        public abstract string ShowState();
    }
}
