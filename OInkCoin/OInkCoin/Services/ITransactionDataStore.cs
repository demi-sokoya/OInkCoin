using System;
using System.Collections.Generic;
using System.Text;
using OinkCoin.Models;
using System.Threading.Tasks;


namespace OinkCoin.Services
{
    
        public interface ITransactionDataStore<T>
        {
            Task<IEnumerable<Transaction>> GetTransactions();
            Task<Transaction> GetTransaction(int transactionId);
            Task AddTransaction(Transaction transaction);
            Task UpdateTransaction(Transaction transaction);
        }
    }

