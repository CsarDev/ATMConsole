using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMConsole
{
    public class ATMSystem : ITransaction
    {
        private static List<Transaction> _listOfTransactions;

        public ATMSystem() 
        {
            _listOfTransactions = new List<Transaction>();
        }
        public void ViewTransaction(BankAccount bankAccount)
        {

            if (_listOfTransactions.Count <= 0)
                Utility.PrintMessage($"There is no transaction yet.", true);
            else
            {
                var table = new ConsoleTable("Type", "From", "To", "Amount " + ATMScreen.cur, "Transaction Date");

                foreach (var tran in _listOfTransactions)
                {
                    table.AddRow(tran.TransactionType, tran.BankAccountNoFrom, tran.BankAccountNoTo, tran.TransactionAmount,
                    tran.TransactionDate);
                }
                table.Options.EnableCount = false;
                table.Write();
                Utility.PrintMessage($"You have performed {_listOfTransactions.Count} transactions.", true);
            }
        }

        public void InsertTransaction(BankAccount bankAccount, Transaction transaction)
        {
            _listOfTransactions.Add(transaction);
        }

        public void InsertTransaction(Transaction transaction)
        {
            _listOfTransactions.Add(transaction);
        }
    }
}
