using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1109
{
    // recoed - состояние объектов этого класса нельзя изменить 
    internal record Transaction (decimal Amount, DateTime Date, string Note);
    
    // более обширенный - можно его использовать когда нужно произвести проверку 
    //internal record Transaction
    //{
    //    public decimal Amount { get;  }
    //    public DateTime Date { get; }
    //    public string Note { get; }

    //    public Transaction(decimal Amount, DateTime Date, string
    //        Note)
    //    {
    //        this.Amount = Amount;
    //        this.Date = Date;
    //        this.Note = Note;
    //    }
    //}
}
