using System;
using System.Collections.Generic;
using System.Text;
//using System.ComponentModel.DataAnnotations;

namespace OinkCoin.Models
{
    public class Transaction
    {
        //[PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public Category ChosenCategory { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public bool Recurring { get; set; }
        public int NumOfPayments { get; set; }
        public AccountType Account { get; set; }

        public enum AccountType
        {
            Credit = 0,
            Debit = 1
        }
        public enum TransactionType
        {
            Expense = 0,
            Transfer = 1
        }






    }
}
