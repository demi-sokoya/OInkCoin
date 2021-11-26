using System;
using System.Collections.Generic;
using System.Text;
using OInkCoin.Models;
using System.Threading.Tasks;


namespace OInkCoin.Services
{
    
        public interface ITransactionDataStore<T>
        {
            Task<IEnumerable<Transaction>> GetTransactions();
            Task<Transaction> GetTransaction(int transactionId);
            Task AddTransaction(Transaction transaction);
            Task UpdateTransaction(Transaction transaction);
        }
    }

