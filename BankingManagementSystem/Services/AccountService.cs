using System;
using System.Collections.Generic;
using System.Linq;
using Banking_Management_System.Models;

namespace Banking_Management_System.Services
{

    public class AccountService : IAccountService
    {
        private int nextCustomerId = 1;
        private int nextAccountId = 1;
        private readonly List<Customer> customers;

        public AccountService()
        {
            customers = new List<Customer>();
        }

        public void CreateNewCustomer(string name, DateTime dob, string address, string phoneNumber, string accountType)
        {
            var account = CreateAccount(accountType);

            var customer = new Customer
            {
                CustomerId = nextCustomerId++,
                Name = name,
                DOB = dob,
                Address = address,
                PhoneNumber = phoneNumber,
                AccountType = accountType,
                Account = account
            };

            account.AccountId = nextAccountId++;
            account.UserName = GenerateUserName(name);
            account.Password = GeneratePassword();
            account.AccountNumber = GenerateAccountNumber();

            customers.Add(customer);

            Console.WriteLine("Customer registration successful!");
            Console.WriteLine($"Username: {account.UserName}");
            Console.WriteLine($"Password: {account.Password}");
        }

        public bool AuthenticateCustomer(string userName, string password)
        {
            return customers.Any(c => c.Account.UserName == userName && c.Account.Password == password);
        }

        public List<Customer> GetAllCustomers()
        {
            return customers;
        }

        private Account CreateAccount(string accountType)
        {
            return accountType.ToLower() switch
            {
                "savings" => new SavingsAccount(),
                "current" => new CurrentAccount(),
                _ => throw new ArgumentException("Invalid account type")
            };
        }

        private string GenerateAccountNumber()
        {
            return "304801000" + new Random().Next(10000, 99999);
        }

        private string GeneratePassword()
        {
            return "Pass@" + new Random().Next(1000, 9999);
        }

        private string GenerateUserName(string name)
        {
            return name.ToLower() + "user" + new Random().Next(1000, 9999);
        }
    }
}
