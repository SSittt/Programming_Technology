namespace Events
{
    public sealed class BidPlacedEventArgs: EventArgs
    {
        public string Title { get; }

        public string Bidder { get; }

        public decimal? PreviosAmount { get; }

        public string PreviosLeader { get; }

        public decimal Amount { get; }

        public BidPlacedEventArgs(string title, string bidDer, decimal? previosAmount, string previosLeader, decimal amount)
        {
            Title = title;
            Bidder = bidDer;
            PreviosAmount = previosAmount;
            PreviosLeader = previosLeader;
            Amount = amount;

        }
    }