using System;
using Banking_Management_System.Models;

public interface IAccountService
{
    void CreateNewCustomer(string name, DateTime dob, string address, string phoneNumber, string accountType);
    bool AuthenticateCustomer(string userName, string password);
    List<Customer> GetAllCustomers();
}