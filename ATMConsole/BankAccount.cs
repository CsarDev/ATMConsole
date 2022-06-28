
using System;
namespace ATMConsole
{
    public class BankAccount
    {
        public string FullName { get; set; }
        public Int64 AccountNumber { get; set; }
        public Int64 CardNumber { get; set; }
        public Int64 PinCode { get; set; }
        public decimal Balance { get; set; }

        public bool isLocked { get; set; }

        public BankAccountState state;

        public BankAccount(){
            state = new ActiveState();
            isLocked = false;
        }
        public void changeState(BankAccountState state) { this.state = state; }
    }
}

