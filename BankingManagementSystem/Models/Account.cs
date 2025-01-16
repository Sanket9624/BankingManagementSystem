using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Banking_Management_System.Models;

namespace Banking_Management_System.Models
{
   public abstract class Account : IAccount
    {
        public int AccountId { get; set; }
        [Required]
        public string AccountNumber { get; set; } = null!;
        public decimal Balance { get; set; }
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public virtual void Deposit(decimal amount)
        {
            Balance += amount;
            AddTransaction("Deposit", amount);
            Console.WriteLine($"Deposited {amount}. New balance: {Balance}");
        }

        public virtual void Withdraw(decimal amount)
        {
            if (Balance < amount)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }

            Balance -= amount;
            AddTransaction("Withdraw", amount);
            Console.WriteLine($"Withdrew {amount}. New balance: {Balance}");
        }

        public void ViewTransactionHistory()
        {
            Console.WriteLine($"Transaction history for account {AccountNumber}:");
            foreach (var transaction in Transactions)
            {
                Console.WriteLine($"ID: {transaction.TransactionId}, Type: {transaction.TransactionType}, Amount: {transaction.Amount}, Balance: {transaction.Balance}, Date: {transaction.Date}");
            }
        }

        public void CheckBankBalance()
        {
            Console.WriteLine($"Current balance: {Balance}");
        }
        public void ViewAccountDetails()
        {
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Account Balance: {Balance}");
            Console.WriteLine($"Account Holder: {UserName}");
            Console.WriteLine($"Total Transactions: {Transactions.Count}");

            // Display transaction history
            Console.WriteLine("Recent Transactions:");
            foreach (var transaction in Transactions.OrderByDescending(t => t.Date).Take(5))
            {
                Console.WriteLine($"ID: {transaction.TransactionId}, Type: {transaction.TransactionType}, Amount: {transaction.Amount}, Balance: {transaction.Balance}, Date: {transaction.Date}");
            }
        }


        protected void AddTransaction(string type, decimal amount)
        {
            Transactions.Add(new Transaction
            {
                TransactionId = Transactions.Count + 1,
                AccountId = AccountId,
                TransactionType = type,
                Amount = amount,
                Balance = Balance,
                Date = DateTime.Now
            });
        }
    }
}
