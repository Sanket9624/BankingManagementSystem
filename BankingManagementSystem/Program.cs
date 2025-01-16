using Banking_Management_System.Services;

namespace Banking_Management_System
{
    public class Program
    {
        static void Main(string[] args)
        {
            AccountService accountService = new AccountService();
            BankingServices bankingService = new BankingServices(accountService.GetAllCustomers());

            Console.WriteLine("Simple Banking System");
            while (true)
            {
                Console.WriteLine("\n--Main Menu--");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.Write("Enter Your Choice: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Register(accountService);
                        break;

                    case "2":
                        if (Login(accountService, out string userName))
                        {
                            Console.WriteLine("\nLogin Successful. Welcome!");
                            UserMenu(bankingService, userName);
                        }
                        break;

                    case "3":
                        Console.WriteLine("Thank you for using our banking system. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid Choice. Please try again.");
                        break;
                }
            }
        }

        static void Register(AccountService accountService)
        {
            Console.WriteLine("\n---Register New Customer---");

            Console.Write("Enter Your Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Your Date of Birth (yyyy-mm-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dob))
            {
                Console.WriteLine("Invalid date format. Please try again.");
                return;
            }

            Console.Write("Enter Your Address: ");
            string address = Console.ReadLine();

            Console.Write("Enter Your Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter Account Type (savings/current): ");
            string accountType = Console.ReadLine();

            accountService.CreateNewCustomer(name, dob, address, phoneNumber, accountType);
        }

        static bool Login(AccountService accountService, out string userName)
        {
            Console.WriteLine("\n---Login---");
            Console.Write("Enter Username: ");
            userName = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            if (accountService.AuthenticateCustomer(userName, password))
                return true;

            Console.WriteLine("Invalid Username or Password. Please try again.");
            return false;
        }

        static void UserMenu(BankingServices bankingService, string userName)
        {
            while (true)
            {
                Console.WriteLine("\n--User Menu--");
                Console.WriteLine("1. Deposit Money");
                Console.WriteLine("2. Withdraw Money");
                Console.WriteLine("3. Transfer Money");
                Console.WriteLine("4. View Transaction History");
                Console.WriteLine("5. Check Bank Balance");
                Console.WriteLine("6. View AccountDetails");
                Console.WriteLine("7. Logout");
                Console.Write("Enter Your Choice: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        bankingService.DepositMoney(userName);
                        break;

                    case "2":
                        bankingService.WithdrawMoney(userName);
                        break;

                    case "3":
                        bankingService.TransferMoney(userName);
                        break;

                    case "4":
                        bankingService.ViewTransactionHistory(userName);
                        break;

                    case "5":
                        bankingService.CheckBankBalance(userName);
                        break;

                    case "6":
                        bankingService.SeeAccountDetails(userName);
                        break;

                    case "7":
                        Console.WriteLine("Logged out successfully.");
                        return;

                    default:
                        Console.WriteLine("Invalid Choice. Please try again.");
                        break;
                }
            }
        }
    }
}
