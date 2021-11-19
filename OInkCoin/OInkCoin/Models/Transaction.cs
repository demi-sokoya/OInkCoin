using System;
using System.Collections.Generic;
using System.Text;
//using System.ComponentModel.DataAnnotations;

namespace OInkCoin.Models
{
    public class Transaction
    {
        //[PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public ICollection<TransactionType> Transactions { get; set; }
        public ICollection<Category> Category { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public bool Recurring { get; set; }
        public DateTime ReccuringStart { get; set; }
        public DateTime RecuringEnd { get; set; }
        public int NumOfPayments { get; set; }
        public List<Accounts> Account { get; set; }

        public class Accounts
        {
            public int Id { get; set; }
            public enum Types
            {
                Credit,
                Debit
            }
        }

        



    }
}
