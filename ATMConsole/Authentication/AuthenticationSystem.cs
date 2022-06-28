using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMConsole
{
    public class AuthenticationSystem: ILogin
    {
        private static BankAccount selectedAccount;
        private static BankAccount inputAccount;

        private static int tries;
        private const int maxTries = 3;

        public BankAccount CheckCardNoPassword(List<BankAccount> _accountList)
        {
            bool pass = false;

            while (!pass)
            {
                inputAccount = new BankAccount();

                Console.WriteLine("\nNote: Actual ATM system will accept user's ATM card to validate");
                Console.Write("and read card number, bank account number and bank account status. \n\n");
                //Console.Write("Enter ATM Card Number: ");
                //inputAccount.CardNumber = Convert.ToInt32(Console.ReadLine());
                inputAccount.CardNumber = Utility.GetValidIntInputAmt("ATM Card Number");

                Console.Write("Enter 6 Digit PIN: ");
                inputAccount.PinCode = Convert.ToInt32(Utility.GetHiddenConsoleInput());
                // for brevity, length 6 is not validated and data type.


                System.Console.Write("\nChecking card number and password.");
                Utility.printDotAnimation();

                foreach (BankAccount account in _accountList)
                {
                    if (inputAccount.CardNumber.Equals(account.CardNumber))
                    {
                        selectedAccount = account;

                        if (inputAccount.PinCode.Equals(account.PinCode))
                        {
                            if (selectedAccount.isLocked)
                                LockAccount();
                            else
                                pass = true;


                        }
                        else
                        {

                            pass = false;
                            tries++;

                            
                            
                            if (tries >= maxTries)
                            {
                                selectedAccount.state.CheckState(selectedAccount);
                                selectedAccount.state.ShowState();

                                LockAccount();
                            }

                        }
                    }
                }

                if (!pass)
                    Utility.PrintMessage("Invalid Card number or PIN.", false);

                Console.Clear();
            }
            return selectedAccount;
        }

        private static void LockAccount()
        {
            Console.Clear();
            Utility.PrintMessage("Your account is locked.", true);
            Console.WriteLine("Please go to the nearest branch to unlocked your account.");
            Console.WriteLine("Thank you for using Meybank. ");
            Console.ReadKey();
            System.Environment.Exit(1);
        }
    }
}
