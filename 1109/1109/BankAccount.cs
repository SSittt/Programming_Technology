using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// USING SYSTEM.TRANSACTION из-за него может возикнцть ошибка 
namespace _1109
{
  
    /// <summary>
    /// пользовательский тип данных 
    /// </summary>
    public enum Status
    {
        Regular,
        Primium,
        VIP
    }

    //BankAccount потомок object => можно переопределить 
    //виртуальные методы, находящиес в object
    /// <summary>
    /// Банковский счет клиента 
    /// </summary>
    public class BankAccount
    {
        private readonly decimal _minimumBalance;
        // ctrl + f переименование naming 
        static private int accountNumberSeed = 1000000000; // номер счета 
        /// <summary>
        /// номер счета
        /// </summary>
        public string Number {  get; } 
        /// <summary>
        /// Владелец счета 
        /// </summary>
        public string Owner { get; private set; }
        /// <summary>
        /// Ствтус 
        /// </summary>
        public Status Status { get; set; }

        

        /// <summary>
        /// возвращает текущий баланс банковского счета 
        /// </summary>
        public decimal Balance 
        {
            get
            {
                decimal balance = 0;
                foreach (var item in _allTransaction)
                {
                    balance += item.Amount;

                }
                return balance;
            }

        }
    
        private List<Transaction> _allTransaction = new List<Transaction>(); //создается новые листа когда создается новый объект 


        private List<AuditLog> auditLogs = new List<AuditLog>();


        /// <summary>
        /// Создает банковский счет с указанным владельцем и начальным балансом
        /// </summary>
        /// <param name="name">имя владельца</param>
        /// <param name="initialBalance">начальный баланс счета</param>
        public BankAccount(string name, decimal initialBalance)
            : this(name, initialBalance, 0) { }


        /// <summary>
        ///  создает банковский счет с владельцем и начальным балансом и мин допустимим балансом.
        /// </summary>
        /// <param name="name">имя владельца</param>
        /// <param name="initialBalance">начальный баланс счета </param>
        /// <param name="minimumBalance">минимальный допустимый баланс счета</param>
        public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
        {
           
            Owner = name; // если имена одинаковый, поэтому this.owner = name

            Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            _minimumBalance = minimumBalance;


            if (initialBalance > 0) 
            {
                MakeDeposit(initialBalance, DateTime.UtcNow, "Initial balance");
            }
        }

        /// <summary>
        /// Пополнение счета на указанную сумму 
        /// </summary>
        /// <param name="amount">транзакция </param>
        /// <param name="date">дата транзакции</param>
        /// <param name="note">коммент транзакции</param>
        /// <exception cref="ArgumentOutOfRangeException">исключение, если сумма пополнение меньше или = 0</exception>
        public void MakeDeposit(decimal amount, DateTime date, string note) // пополнение
        {
            if (amount <= 0) 
            { 
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            
            var deposit = new Transaction(amount, date, note); // для добавление в список транзации 
            _allTransaction.Add(deposit);

            auditLogs.Add(new AuditLog(Number, "Deposit", amount, date));

        }

        /// <summary>
        ///  Снимает указанную сумму с банковского счёта.
        /// </summary>
        /// <param name="amount"> транзакция</param>
        /// <param name="date">дата транзакции</param>
        /// <param name="note">коммент транзакции</param>
        public void MakeWithdrawal(decimal amount, DateTime date, string note) // снятие
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
            Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);
            Transaction? withdrawal = new Transaction(-amount, date, note);
            _allTransaction.Add(withdrawal);

            auditLogs.Add(new AuditLog(Number, "Withdrawal",amount , date));

            if (overdraftTransaction != null) {
                _allTransaction.Add(overdraftTransaction);
            
            }
            //if (amount <= 0) 
            //{
            //    throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");

            //}

            //if (Balance < amount)
            //{
            //    throw new InvalidOperationException("Not sufficient rubls for this withdrawal");
            //}
            //var withdrawal = new Transaction(-amount, date, note);
            //_allTransaction.Add(withdrawal);
        }

        /// <summary>
        /// проверка возможности выполенение операции снятие средств
        /// </summary>
        /// <param name="v">Значение, указывающее, превышен ли допустимый лимит снятия</param>
        /// <returns>Доп транзакция или null, если доп транзакция не требуется</returns>
        /// <exception cref="InvalidOperationException">исключение, если операция превышает допустимый лимит снятия </exception>
        protected virtual Transaction? CheckWithdrawalLimit(bool v)
        {
            if (v) 
            {
                throw new InvalidOperationException("Not sufficient rubls for this withdrawal");
            }
            return default;
        }


        /// <summary>
        /// возвращает историю банковского счета 
        /// </summary>
        /// <returns> Строку с датами операций, суммами, балансами и комментами</returns>
        public string GetAccountHistory()
        {
            var repost = new StringBuilder();
            decimal balance = 0;
            repost.AppendLine("Data\t\tAmount\tBalance\tNote");
            foreach (var item in _allTransaction)
            {
                balance += item.Amount;
                repost.AppendLine($"" + $"{item.Date.ToShortDateString()}\t" + $"{item.Amount}\t {balance}\t {item.Note}");
            }
            return repost.ToString();
        }

        // ключевое слово virtual позволяет в дочернем классе 
        // предоставить другую реализацию
        // метод PerformMonthAndtransaction()

        /// <summary>
        /// выбирает статус клиента, рассчитывает комиссию и выполняет списание
        /// </summary>
        public virtual void PerformMonthAndtransaction()
        {
            switch (Status)
            {
                case Status.Regular:
                    MakeWithdrawal(50, DateTime.UtcNow, "Monthly service fee");
                break;

                case Status.Primium:
                    if(Balance > 10000)
                    {
                        decimal fee = (Balance - 10000) * 0.01m;
                        MakeWithdrawal(fee, DateTime.UtcNow, "Premium fee");
                    }
                break;

                case Status.VIP:
                    if(Balance > 10000)
                    {
                        decimal fee = (Balance - 10000) * 0.003m;
                        MakeWithdrawal(fee, DateTime.UtcNow, "VIP fee");
                    }
                    decimal cashback = 0;

                    foreach(var transaction  in _allTransaction)
                    {
                        if (transaction.Amount > 0)
                            cashback += Math.Abs(transaction.Amount) * 0.05m;
                        if (cashback > 0)
                            MakeDeposit(cashback, DateTime.UtcNow, "VIP cashback");
                        break;
                    }
                break;
            }
        }

        /// <summary>
        ///  выводит журнал операций с инфой обо всех операций банковского счета
        /// </summary>
        public void GetAuditLog()
        {
            foreach (var auditLog in auditLogs)
            {
                Console.WriteLine(auditLog);
            }
        }

        /// <summary>
        /// проверяет возможность перевода, списывает деньги и пополняет другой счёт.
        /// </summary>
        /// <param name="account"> счет, с которого будет переводится </param>
        /// <param name="amount">сумма перевода </param>
        /// <exception cref="ArgumentNullException"> если счет получателя = null</exception>
        public void Transfer (BankAccount account, decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentNullException(nameof(amount), "Amount must be positive");
            }
            if (Balance - amount < _minimumBalance) 
            {
                throw new ArgumentNullException(nameof(amount), "Not enough money for transfer");
            }
            MakeWithdrawal(amount, DateTime.UtcNow, "Transfer");
            account.MakeDeposit(amount, DateTime.UtcNow, "Tranfer");
        }

        //пуреопределяем метод, который кнаследовал от object
        //этот метод должен возвращать строку с состояннием объекта 
        // 1- способ 
        //public override string ToString()
        //{
        //    return $"Type: {GetType().Name}\tOwmer: {Owner} \t Number of account:{Number}";
        //}

        // 2- способ 

        /// <summary>
        /// возвращает в строку банковский счет 
        /// </summary>
        /// <returns>Строку с типом счёта, владельцем и номером счёта </returns>
        public override string ToString()
        =>  $"Type: {GetType().Name}\tOwmer: {Owner} \t Number of account: {Number} ";

    }
}
