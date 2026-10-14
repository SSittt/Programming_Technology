namespace _1109
{
    public class Program
    {
        /// <summary>
        /// Запускает приложение и демонстрирует операции с банковскими счетами
        /// </summary>
        /// <param name="args"></param>
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
                Console.WriteLine();
            }
            InterestEarningAccount interestEarning = new("YANA", 1000m);
            interestEarning.MakeDeposit(100m, DateTime.UtcNow, ":)");
            interestEarning.MakeDeposit(10m, DateTime.UtcNow, ":(");
            interestEarning.PerformMonthAndtransaction();
            Console.WriteLine(interestEarning.GetAccountHistory());


            LineOfCreditAccount lineOfCredit = new LineOfCreditAccount("Yana", 0, 1000m);
            lineOfCredit.MakeWithdrawal(500m, DateTime.UtcNow, "credit");

            GiftCartAccount giftCart = new("Yana", 1000m, 5000m);

            List<BankAccount> Accounts = new List<BankAccount>();
            Accounts.Add(account);
            Accounts.Add(interestEarning);
            Accounts.Add(lineOfCredit);
            Accounts.Add(giftCart);

            foreach (BankAccount bankAccount in Accounts)
            {
                Console.WriteLine(bankAccount);
                bankAccount.PerformMonthAndtransaction();
                Console.WriteLine(bankAccount.GetAccountHistory());
            }
            //Console.WriteLine(interestEarning); // =  Console.WriteLine(interestEarning.ToString());
            //Console.WriteLine(interestEarning.GetAccountHistory());


            //giftCart.MakeDeposit(100m, DateTime.UtcNow, ":)");
            //giftCart.MakeDeposit(10m, DateTime.UtcNow, ":(");
            //giftCart.PerformMonthAndtransaction();
            //Console.WriteLine(giftCart);
            //Console.WriteLine(giftCart.GetAccountHistory());

            BankAccount account1= new BankAccount("Yana", 15000);
            account1.MakeWithdrawal(1000, DateTime.UtcNow, ":(");
            account1.Status = Status.VIP;

            Console.WriteLine($"Before transfer:");
            Console.WriteLine($"account2: {account1.Balance}");

            try
            {
                account.Transfer(account1, 5000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine($"After transfer:");
            Console.WriteLine($"account2: {account1.Balance}");

            account1.PerformMonthAndtransaction();
            Console.WriteLine(account1.GetAccountHistory());
            account1.GetAuditLog();

        }
    }
}
