using System;

public interface IBankingServices
{
    void DepositMoney(string userName);
    void WithdrawMoney(string userName);
    void TransferMoney(string senderUserName);
    void ViewTransactionHistory(string userName);
    void CheckBankBalance(string userName);
    void SeeAccountDetails(string userName);
}