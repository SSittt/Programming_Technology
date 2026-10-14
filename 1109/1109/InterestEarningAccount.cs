using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1109
{   
    /// <summary>
    /// Банковски2й счет с начислением процентов 
    /// </summary>
    internal class InterestEarningAccount: BankAccount
    {
        /// <summary>
        /// создание счета с начислением процентов 
        /// </summary>
        /// <param name="name">имя владельца</param>
        /// <param name="inittialBAlance">начальный баланс счета</param>
        public InterestEarningAccount(string name, decimal inittialBAlance)
            : base(name, inittialBAlance)
        {

        }

        // override  позволяет в дочернем классе определить новую реализацию
        // метода PerformMonthAndtransaction
        /// <summary>
        /// Начисляет ежемесячные проценты на счёт, если баланс превышает 500.
        /// </summary>
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
