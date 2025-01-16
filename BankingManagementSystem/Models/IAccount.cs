using System;

public interface IAccount
{
    void Deposit(decimal amount);
    void Withdraw(decimal amount);
    void ViewTransactionHistory();
    void CheckBankBalance();
}
