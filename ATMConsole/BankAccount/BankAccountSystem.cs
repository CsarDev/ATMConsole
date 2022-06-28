using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace ATMConsole
{
    public class BankAccountSystem: IBalance, IDeposit, IWithdrawal, IThirdPartyTransfer
    {
        //todo: A transaction class with transaction amount can replace these two variable.
        private static decimal transaction_amt;

        private const decimal minimum_kept_amt = 20;

        private static List<BankAccount> _accountList;
         

        private ATMSystem AtmSystem;

        public List<BankAccount> AccountList { get => _accountList; }

        public BankAccountSystem(ATMSystem atmSystem)
        {
            Initialization();
            AtmSystem = atmSystem;
        }
        public void Initialization()
        {
            transaction_amt = 0;

            _accountList = new List<BankAccount>
            {
                new BankAccount() { FullName = "John", AccountNumber=333111, CardNumber = 123, PinCode = 111111, Balance = 2000.00m, isLocked = false },
                new BankAccount() { FullName = "Mike", AccountNumber=111222, CardNumber = 456, PinCode = 222222, Balance = 1500.30m, isLocked = true },
                new BankAccount() { FullName = "Mary", AccountNumber=888555, CardNumber = 789, PinCode = 333333, Balance = 2900.12m, isLocked = false }
            };
        }

        public void CheckBalance(BankAccount bankAccount)
        {
            Utility.PrintMessage($"Your bank account balance amount is: {Utility.FormatAmount(bankAccount.Balance)}", true);
        }

        public void PlaceDeposit(BankAccount account)
        {

            Console.WriteLine("\nNote: Actual ATM system will just let you ");
            Console.Write("place bank notes into ATM machine. \n\n");
            //Console.Write("Enter amount: " + ATMScreen.cur);
            transaction_amt = Utility.GetValidDecimalInputAmt("amount");

            System.Console.Write("\nCheck and counting bank notes.");
            Utility.printDotAnimation();

            if (transaction_amt <= 0)
                Utility.PrintMessage("Amount needs to be more than zero. Try again.", false);
            else if (transaction_amt % 10 != 0)
                Utility.PrintMessage($"Key in the deposit amount only with multiply of 10. Try again.", false);
            else if (!PreviewBankNotesCount(transaction_amt))
                Utility.PrintMessage($"You have cancelled your action.", false);
            else
            {
                // Bind transaction_amt to Transaction object
                // Add transaction record - Start
                var factory = new DepositFactory(account.AccountNumber, account.AccountNumber, transaction_amt);

                var depositTransation = factory.GetTransaction();

                AtmSystem.InsertTransaction(account, depositTransation);
                // Add transaction record - End

                // Another method to update account balance.
                account.Balance = account.Balance + transaction_amt;

                Utility.PrintMessage($"You have successfully deposited {Utility.FormatAmount(transaction_amt)}", true);
            }
        }

        public void MakeWithdrawal(BankAccount account)
        {
            Console.WriteLine("\nNote: For GUI or actual ATM system, user can ");
            Console.Write("choose some default withdrawal amount or custom amount. \n\n");

            // Console.Write("Enter amount: " + ATMScreen.cur);
            // transaction_amt = ATMScreen.ValidateInputAmount(Console.ReadLine());

            transaction_amt = Utility.GetValidDecimalInputAmt("amount");

            if (transaction_amt <= 0)
                Utility.PrintMessage("Amount needs to be more than zero. Try again.", false);
            else if (transaction_amt > account.Balance)
                Utility.PrintMessage($"Withdrawal failed. You do not have enough fund to withdraw {Utility.FormatAmount(transaction_amt)}", false);
            else if ((account.Balance - transaction_amt) < minimum_kept_amt)
                Utility.PrintMessage($"Withdrawal failed. Your account needs to have minimum {Utility.FormatAmount(minimum_kept_amt)}", false);
            else if (transaction_amt % 10 != 0)
                Utility.PrintMessage($"Key in the deposit amount only with multiply of 10. Try again.", false);
            else
            {
                // Bind transaction_amt to Transaction object
                // Add transaction record - Start

                var factory = new WithdrawalFactory(account.AccountNumber, account.AccountNumber, transaction_amt);

                var withdrawalTransation = factory.GetTransaction();

                AtmSystem.InsertTransaction(account, withdrawalTransation);
                // Add transaction record - End

                // Another method to update account balance.
                account.Balance = account.Balance - transaction_amt;

                Utility.PrintMessage($"Please collect your money. You have successfully withdraw {Utility.FormatAmount(transaction_amt)}", true);
            }
        }

        public void PerformThirdPartyTransfer(BankAccount bankAccount, VMThirdPartyTransfer vMThirdPartyTransfer)
        {
            if (vMThirdPartyTransfer.TransferAmount <= 0)
                Utility.PrintMessage("Amount needs to be more than zero. Try again.", false);
            else if (vMThirdPartyTransfer.TransferAmount > bankAccount.Balance)
                // Check giver's account balance - Start
                Utility.PrintMessage($"Withdrawal failed. You do not have enough fund to withdraw {Utility.FormatAmount(transaction_amt)}", false);
            else if (bankAccount.Balance - vMThirdPartyTransfer.TransferAmount < 20)
                Utility.PrintMessage($"Withdrawal failed. Your account needs to have minimum {Utility.FormatAmount(minimum_kept_amt)}", false);
            // Check giver's account balance - End
            else
            {
                // Check if receiver's bank account number is valid.
                var selectedBankAccountReceiver = (from b in AccountList
                                                   where b.AccountNumber == vMThirdPartyTransfer.RecipientBankAccountNumber
                                                   select b).FirstOrDefault();

                if (selectedBankAccountReceiver == null)
                    Utility.PrintMessage($"Third party transfer failed. Receiver bank account number is invalid.", false);
                else if (selectedBankAccountReceiver.FullName != vMThirdPartyTransfer.RecipientBankAccountName)
                    Utility.PrintMessage($"Third party transfer failed. Recipient's account name does not match.", false);
                else
                {
                    // Bind transaction_amt to Transaction object
                    // Add transaction record - Start

                    var factory = new ThirdPartyTransferFactory(bankAccount.AccountNumber, vMThirdPartyTransfer.RecipientBankAccountNumber, transaction_amt);

                    var withdrawalTransation = factory.GetTransaction();

                    AtmSystem.InsertTransaction(withdrawalTransation);
                    Utility.PrintMessage($"You have successfully transferred out {Utility.FormatAmount(vMThirdPartyTransfer.TransferAmount)} to {vMThirdPartyTransfer.RecipientBankAccountName}", true);
                    // Add transaction record - End

                    // Update balance amount (Giver)
                    bankAccount.Balance = bankAccount.Balance - vMThirdPartyTransfer.TransferAmount;

                    // Update balance amount (Receiver)
                    selectedBankAccountReceiver.Balance = selectedBankAccountReceiver.Balance + vMThirdPartyTransfer.TransferAmount;
                }
            }

        }

        private static bool PreviewBankNotesCount(decimal amount)
        {
            int hundredNotesCount = (int)amount / 100;
            int fiftyNotesCount = ((int)amount % 100) / 50;
            int tenNotesCount = ((int)amount % 50) / 10;

            Console.WriteLine("\nSummary");
            Console.WriteLine("-------");
            Console.WriteLine($"{ATMScreen.cur} 100 x {hundredNotesCount} = {100 * hundredNotesCount}");
            Console.WriteLine($"{ATMScreen.cur} 50 x {fiftyNotesCount} = {50 * fiftyNotesCount}");
            Console.WriteLine($"{ATMScreen.cur} 10 x {tenNotesCount} = {10 * tenNotesCount}");
            Console.Write($"Total amount: {Utility.FormatAmount(amount)}\n\n");

            //Console.Write("\n\nPress 1 to confirm or 0 to cancel: ");
            string opt = Utility.GetValidIntInputAmt("1 to confirm or 0 to cancel").ToString();

            return (opt.Equals("1")) ? true : false;
        }
    }
}
