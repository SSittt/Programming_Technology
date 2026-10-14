using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1109
{
    /// <summary>
    /// Создание банковского счета с ежемесячне пополнением 
    /// </summary>
    public class GiftCartAccount : BankAccount
    {
        private readonly decimal _monthlyDeposit = 0m;

        // monthlyDeposit - параметр по умолчанию (принимает 0)
        // при создании new GiftCartAccount ("YANA" , 1000); => monthlyDeposit =0
        // GiftCartAccou ("nasy", 1000, 5000); => monthlyDeposit = 5000


        /// <summary>
        /// создание банковского счета с ежемесячнем пополнением 
        /// </summary>
        /// <param name="name">имя владельца</param>
        /// <param name="initialBalance">начальный баланс счета</param>
        /// <param name="monthlyDeposit">сумма ежемесячного пополнение счсета</param>
        public GiftCartAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0)
            : base(name, initialBalance) => _monthlyDeposit = monthlyDeposit;


        /// <summary>
        /// выполняет ежемесячное пополнение счета 
        /// </summary>
        public override void PerformMonthAndtransaction()
        {
            if (_monthlyDeposit > 0)
            {
                MakeDeposit(_monthlyDeposit, DateTime.UtcNow, "Add monthly deposit");
            }
        }

        // base.ToString() - вызов базовогй реализации =Ю реализация из класса BankAcoount 
        /// <summary>
        /// возвращает в строку счет 
        /// </summary>
        /// <returns>строка с инфой о банковском счете и ск=умме ежемесячного пополнение </returns>
        public override string ToString()
        {
            return base.ToString() + $"monthly deposit: {_monthlyDeposit}";
        }
    }
}