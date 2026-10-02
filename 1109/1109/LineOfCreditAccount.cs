using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1109
{
    public class LineOfCreditAccount: BankAccount
    {
        public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit)
            : base(name, initialBalance, -creditLimit) { }

        public override void PerformMonthAndtransaction()
        {
            if (Balance < 0)
            {
                decimal interest = -Balance + 0.07m;
                MakeWithdrawal(interest, DateTime.UtcNow, "Change monthly interest");
            }
        }

        protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) => isOverdrawn ?
            new Transaction(-20, DateTime.UtcNow, "apply overdeaft"):default;

    }
}
