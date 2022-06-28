using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Globalization;
using System.Threading;
using ConsoleTables;
using ATMConsole;

namespace MeybankATMSystem
{
    class MeybankATM 
    {

        private ATMFacade atmFacade;

        public void Execute()
        {
            Initialization();
            ATMScreen.ShowMenu1();

            while (true)
            {
                switch (Utility.GetValidIntInputAmt("your option"))
                {
                    case 1:
                        atmFacade.CheckCardNoPassword();

                        while (true)
                        {
                            ATMScreen.ShowMenu2();

                            switch (Utility.GetValidIntInputAmt("your option"))
                            {
                                case (int)SecureMenu.CheckBalance:
                                    atmFacade.CheckBalance();
                                    break;
                                case (int)SecureMenu.PlaceDeposit:
                                    atmFacade.PlaceDeposit();
                                    break;
                                case (int)SecureMenu.MakeWithdrawal:
                                    atmFacade.MakeWithdrawal();
                                    break;
                                case (int)SecureMenu.ThirdPartyTransfer:
                                    var vMThirdPartyTransfer = new VMThirdPartyTransfer();
                                    vMThirdPartyTransfer = ATMScreen.ThirdPartyTransferForm();

                                    atmFacade.PerformThirdPartyTransfer(vMThirdPartyTransfer);
                                    break;
                                case (int)SecureMenu.ViewTransaction:
                                    atmFacade.ViewTransaction();
                                    break;

                                case (int)SecureMenu.Logout:
                                    Utility.PrintMessage("You have succesfully logout. Please collect your ATM card..", true);

                                    Execute();
                                    break;
                                default:
                                    Utility.PrintMessage("Invalid Option Entered.", false);

                                    break;
                            }
                        }

                    case 2:
                        Console.Write("\nThank you for using Meybank. Exiting program now .");
                        Utility.printDotAnimation(15);

                        System.Environment.Exit(1);
                        break;
                    default:
                        Utility.PrintMessage("Invalid Option Entered.", false);
                        break;
                }
            }
        }

        public void Initialization()
        {
            atmFacade = new ATMFacade();
            
        }
    }
}
