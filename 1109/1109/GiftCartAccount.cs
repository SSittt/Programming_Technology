using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1109
{
    public class GiftCartAccount : BankAccount
    {
        private readonly decimal _monthlyDeposit = 0m;
        // monthlyDeposit - параметр по умолчанию (принимает 0)
        // при создании new GiftCartAccount ("YANA" , 1000); => monthlyDeposit =0
        // GiftCartAccou ("nasy", 1000, 5000); => monthlyDeposit = 5000
        public GiftCartAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0)
            : base(name, initialBalance) => _monthlyDeposit = monthlyDeposit;



        public override void PerformMonthAndtransaction()
        {
            if (_monthlyDeposit > 0)
            {
                MakeDeposit(_monthlyDeposit, DateTime.UtcNow, "Add monthly deposit");
            }
        }

        // base.ToString() - вызов базовогй реализации =Ю реализация из класса BankAcoount 
        public override string ToString()
        {
            return base.ToString() + $"monthly deposit: {_monthlyDeposit}";
        }
    }
}