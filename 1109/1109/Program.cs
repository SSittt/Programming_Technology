namespace _1109
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount("yana", 100000); // инфа о владельце 
            BankAccount account2 = new BankAccount("Liana", 10);
            Console.WriteLine($"account {account.Balance} № {account.Number} {account.Owner}");
            Console.WriteLine($"account {account2.Balance} № {account2.Number} {account2.Owner}");

            account.MakeDeposit(20000, DateTime.UtcNow, ":)");
            Console.WriteLine(account.Balance);
            account.MakeWithdrawal(1000, DateTime.UtcNow, ":(");
            Console.WriteLine(account.Balance);

            try
            {
                account2.MakeWithdrawal(1000, DateTime.UtcNow, ":(");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
