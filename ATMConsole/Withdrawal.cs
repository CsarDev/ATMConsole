using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMConsole
{
    class Withdrawal : TransactionFM
    {
        private int _transactionId;
        private Int64 _banckAccountNoFrom;
        private Int64 _banckAccountNoTo;
        private readonly TransactionType _transactionType;
        private decimal _transactionAmount;
        private DateTime _transactionDate;
        
        public Withdrawal(Int64 accountNoFrom, Int64 accountNoTo, decimal transaction_amt)
        {
            _transactionId = 1;
            _banckAccountNoFrom = accountNoFrom;
            _banckAccountNoTo = accountNoTo;
            _transactionType = TransactionType.Withdrawal;
            _transactionAmount = transaction_amt;
            _transactionDate = DateTime.Now;

        }

        public override int TransactionId
        {
            get { return _transactionId; }
        }

        public override Int64 BankAccountNoFrom
        {
            get { return _banckAccountNoFrom; }
            set { _banckAccountNoFrom = value; }
        }


        public override Int64 BankAccountNoTo
        {
            get { return _banckAccountNoTo; }
            set { _banckAccountNoTo = value; }
        }

        public override TransactionType TransactionType
        {
            get { return _transactionType; }
        }
        public override decimal TransactionAmount
        {
            get { return _transactionAmount; }
            set { _transactionAmount = value; }
        }


        public override DateTime TransactionDate
        {
            get { return _transactionDate; }
            set { _transactionDate = value; }
        }

        public TransactionFM MakeWithdrawal() 
        { 
            return null;
        }
         
    }
}
