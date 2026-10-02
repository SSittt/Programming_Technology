using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// USING SYSTEM.TRANSACTION из-за него может возикнцть ошибка 
namespace _1109
{
    //BankAccount потомок object => можно переопределить 
    //виртуальные методы, находящиес в object 
    public class BankAccount
    {
        private readonly decimal _minimumBalance;
        // ctrl + f переименование naming 
        static private int accountNumberSeed = 1000000000; // номер счета 
        public string Number {  get; } // номер счета 
        public string Owner { get; private set; } // влаелец 
        public decimal Balance  // деньга
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

        public BankAccount(string name, decimal initialBalance)
            : this(name, initialBalance, 0) { }
        public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
        {
           
            Owner = name; // если имена одинаковый, поэтому this.owner = name
            _minimumBalance = minimumBalance;
            if (initialBalance < 0) 
            {
                MakeDeposit(initialBalance, DateTime.UtcNow, "Initial balance");
            }

            Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note) // пополнение
        {
            if (amount <= 0) 
            { 
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            
            var deposit = new Transaction(amount, date, note); // для добавление в список транзации 
            _allTransaction.Add(deposit);

        }
        public void MakeWithdrawal(decimal amount, DateTime date, string note) // снятие
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
            Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);
            Transaction? withdrawal = new Transaction(-amount, date, note);
            _allTransaction.Add(withdrawal);

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

        protected virtual Transaction? CheckWithdrawalLimit(bool v)
        {
            if (v) 
            {
                throw new InvalidOperationException("Not sufficient rubls for this withdrawal");
            }
            return default;
        }

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
        public virtual void PerformMonthAndtransaction()
        {
            
        }

        //пуреопределяем метод, который кнаследовал от object
        //этот метод должен возвращать строку с состояннием объекта 
        // 1- способ 
        //public override string ToString()
        //{
        //    return $"Type: {GetType().Name}\tOwmer: {Owner} \t Number of account:{Number}";
        //}

        // 2- способ 

        public override string ToString()
        =>  $"Type: {GetType().Name}\tOwmer: {Owner} \t Number of account:{Number}";
       
    }
}
