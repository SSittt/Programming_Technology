namespace Events
{
    //primare конструктор 
    public sealed class BuyNowTriggerEventAgs(string Buyer, decimal Price) : EventArgs;
}