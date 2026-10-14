using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1109
{
    /// <summary>
    /// журнал операций
    /// </summary>
    public class AuditLog
    {
        /// <summary>
        /// номер счеты
        /// </summary>
        public string Number { get; }
        /// <summary>
        /// тип ореции
        /// </summary>
        public string Operation {  get; }
        /// <summary>
        /// сумма операций
        /// </summary>
        public decimal Amount { get; }
        /// <summary>
        /// дата операции
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// создает запись аудита
        /// </summary>
        /// <param name="Number"> номер счета</param>
        /// <param name="Operation">тип операций</param>
        /// <param name="Amount">сумма операций</param>
        /// <param name="Date">дата операций</param>
        public AuditLog(string Number, string Operation, decimal Amount, DateTime Date)
        {
            this.Number = Number;
            this.Operation = Operation;
            this.Amount = Amount;
            this.Date = Date;
        }

        /// <summary>
        ///  возвращает строку для журнала операций
        /// </summary>
        /// <returns></returns>
        public override string ToString()
     => $"Date:{Date} \tAccount: {Number}\t Operation type:{Operation} \tAmount: {Amount} ";

    }
}
