using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1109
{
    internal class InterestEarningAccount: BankAccount
    {
        public InterestEarningAccount(string name, decimal inittialBAlance)
            : base(name, inittialBAlance)
        {

        }

        // override  позволяет в дочернем классе определить новую реализацию
        // метода PerformMonthAndtransaction
        public override void PerformMonthAndtransaction()
        {
            if (Balance > 500m)
            {
                decimal interest = Balance * 0.02m;
                MakeDeposit(interest, DateTime.UtcNow, "Apply month interest");
            }
        }
    }

}
