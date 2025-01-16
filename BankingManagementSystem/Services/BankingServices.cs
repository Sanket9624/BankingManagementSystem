using System;
using System.Collections.Generic;
using System.Linq;
using Banking_Management_System.Models;

namespace Banking_Management_System.Services
{
    public class BankingServices : IBankingServices
    {
        private readonly List<Customer> customers;

        public BankingServices(List<Customer> customers)
        {
            this.customers = customers;
        }

        public void DepositMoney(string userName)
        {
            Console.Write("Enter Amount to Deposit: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                var account = GetAccount(userName);
                if (account != null)
                {
                    account.Deposit(amount);
                }
                else
                {
                    Console.WriteLine("Invalid Amount. Please try again.");
                }
            }
        }

        public void WithdrawMoney(string userName)
        {
            Console.Write("Enter Amount to Withdraw: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                var account = GetAccount(userName);
                if (account != null)
                {
                    account.Withdraw(amount);
                }
            }
            else
            {
                Console.WriteLine("Invalid Amount. Please try again.");
            }
           
        }

        public void ViewTransactionHistory(string userName)
        {
            var account = GetAccount(userName);
            account.ViewTransactionHistory();
        }

        public void CheckBankBalance(string userName)
        {
            var account = GetAccount(userName);
            account.CheckBankBalance();
        }
        public void TransferMoney(string senderUserName)
        {
            Console.Write("Enter Recipient's Username: ");
            string recipientUserName = Console.ReadLine();

            Console.Write("Enter Amount to Transfer: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                var senderAccount = GetAccount(senderUserName);
                var recipientAccount = GetAccount(recipientUserName);

                if (senderAccount == null)
                {
                    Console.WriteLine("Sender account not found.");
                    return;
                }

                if (recipientAccount == null)
                {
                    Console.WriteLine("Recipient account not found.");
                    return;
                }

                if (senderAccount.Balance < amount)
                {
                    Console.WriteLine("Insufficient funds for transfer.");
                    return;
                }
                if (senderAccount != null && recipientAccount != null) 
                {
                    senderAccount.Withdraw(amount);
                    recipientAccount.Deposit(amount);
                
                    Console.WriteLine($"Successfully transferred {amount} from {senderUserName} to {recipientUserName}.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Amount. Please try again.");
            }
        }
        public void SeeAccountDetails(string userName)
        {
            var account = GetAccount(userName);
            if (account != null)
            {
                account.ViewAccountDetails();
            }
            else
            {
                Console.WriteLine("Account Not Found. Please Try Again");
            }
        }
        private Account GetAccount(string userName)
        {
            var customer = customers.FirstOrDefault(c => c.Account.UserName == userName);
            if (customer == null)
            {
                Console.WriteLine("Account not found.");
                return null;
            }
            return customer.Account;
        }
    }
}
