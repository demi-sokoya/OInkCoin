using System;
using System.Collections.Generic;
using System.Text;

namespace OInkCoin.Models
{
    public class TransactionType
    {
        public int TransactionId { get; set; }
        public enum Transaction
        {
            Expense,
            Transfer
        }
    }
}
