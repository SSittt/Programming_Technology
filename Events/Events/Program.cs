namespace Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // создаем объект
            Lot lot = new Lot("Pencil", 100m, 50m, DateTime.UtcNow.AddDays(1));

            // вызываем метод 
            lot.PlaceBid("Yana", 10_000m);

            lot.BidPlaced += (b, a) => Console.WriteLine($"[LOG] Ставка: {b}-{a}");

            //lot.BidPlaced("Fake", 1_000_000m);

            lot.PlaceBid("Yana", 10_000m);

        }
    }
}
