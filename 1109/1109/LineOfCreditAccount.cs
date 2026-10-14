using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1109
{
    /// <summary>
    /// Банковский йсчет с кредитной линии 
    /// </summary>
    public class LineOfCreditAccount: BankAccount
    {
        /// <summary>
        /// Создаёт банковский счёт с установленным кредитным лимитом
        /// </summary>
        /// <param name="name"> Имя владельца</param>
        /// <param name="initialBalance">Начальный баланс счета</param>
        /// <param name="creditLimit">Размер кредитного лимита</param>
        public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit)
            : base(name, initialBalance, -creditLimit) { }


        /// <summary>
        /// Начисляет ежемесячные проценты при использовании кредитных средств
        /// </summary>
        public override void PerformMonthAndtransaction()
        {
            if (Balance < 0)
            {
                decimal interest = -Balance + 0.07m;
                MakeWithdrawal(interest, DateTime.UtcNow, "Change monthly interest");
            }
        }

        /// <summary>
        /// Проверяет превышение кредитного лимита и создаёт комиссию за использование кредитных средств
        /// </summary>
        /// <param name="isOverdrawn">Значение, указывающее, превышен ли допустимый лимит счёта</param>
        /// <returns> Транзакцию с комиссией или значение null, если лимит не превышен </returns>
        protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) => isOverdrawn ?
            new Transaction(-20, DateTime.UtcNow, "apply overdeaft"):default;

    }
}
