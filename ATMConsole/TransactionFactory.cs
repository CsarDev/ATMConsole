using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMConsole
{
    abstract class TransactionFactory
    {
        public abstract Transaction GetTransaction();
    }
}
