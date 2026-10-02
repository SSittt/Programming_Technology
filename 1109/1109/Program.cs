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
            Console.WriteLine(account2.GetAccountHistory());

            try
            {
                account2.MakeWithdrawal(1000, DateTime.UtcNow, ":(");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            InterestEarningAccount interestEarning = new("YANA", 1000m);
            interestEarning.MakeDeposit(100m, DateTime.UtcNow, ":)");
            interestEarning.MakeDeposit(10m, DateTime.UtcNow, ":(");
            interestEarning.PerformMonthAndtransaction();
            Console.WriteLine(interestEarning.GetAccountHistory());

            Console.WriteLine(interestEarning); // =  Console.WriteLine(interestEarning.ToString());
            Console.WriteLine(interestEarning.GetAccountHistory());

            GiftCartAccount giftCart = new("Yana", 1000m, 5000m);
            giftCart.MakeDeposit(100m, DateTime.UtcNow, ":)");
            giftCart.MakeDeposit(10m, DateTime.UtcNow, ":)");
            giftCart.PerformMonthAndtransaction();

            Console.WriteLine(giftCart);
            Console.WriteLine(giftCart.GetAccountHistory());
        }
    }
}
