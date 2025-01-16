namespace Banking_Management_System.Models
{
    public class SavingsAccount : Account
    {
        public SavingsAccount()
        {
            Balance = 1000; 
        }

        public override void Withdraw(decimal amount)
        {
            if (Balance - amount < 1000)
            {
                Console.WriteLine("Cannot withdraw. Minimum balance requirement of 1000 For Saving Account.");
                return;
            }

            base.Withdraw(amount);
        }
    }

    public class CurrentAccount : Account
    {
        public CurrentAccount()
        {
            Balance = 5000;
        }
        public override void Withdraw(decimal amount)
        {
            if (Balance - amount < 5000)
            {
                Console.WriteLine("Cannot withdraw. Minimum balance requirement of 5000 for Current Account.");
                return;
            }

            base.Withdraw(amount);
        }
    }
}
