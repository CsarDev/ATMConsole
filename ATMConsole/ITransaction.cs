using ATMConsole;

interface ITransaction{
    void InsertTransaction(BankAccount bankAccount, TransactionFM transaction);

    void ViewTransaction(BankAccount bankAccount);
}