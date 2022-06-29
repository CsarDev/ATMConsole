
namespace ATMConsole
{
    public interface IThirdPartyTransfer
    {
        void PerformThirdPartyTransfer(BankAccount bankAccount, VMThirdPartyTransfer vmThirdPartyTransfer);
    }
}