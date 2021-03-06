using Newtonsoft.Json;
using OinkCoin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OinkCoin.Services
{
    class TransactionDataStore : ITransactionDataStore<Transaction>
    {
        public static string FilePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, "Transactions.json");
            }
        }

        private List<Transaction> ReadFile()
        {
            //This line is from my example and is only needed if you want the defaults every time.
            //File.Delete(FilePath);
            try
            {
                var jsonString = File.ReadAllText(FilePath);

                var Transactions = JsonConvert.DeserializeObject<List<Transaction>>(jsonString);

                return Transactions;
            }
            catch (Exception e)
            {
                var defaultTransactions = GetDefaultTransactions();

                WriteFile(defaultTransactions);

                return defaultTransactions;
            }
        }

        private List<Transaction> GetDefaultTransactions()
        {
            var Transactions = new List<Transaction>()
            {
                new Transaction { Id = 1, Amount = 60, Date = DateTime.Now, Recurring = false, Notes = "Dummy entry", Type = Transaction.TransactionType.Expense}
            };

            return Transactions;
        }

        private void WriteFile(List<Transaction> Transactions)
        {
            var jsonString = JsonConvert.SerializeObject(Transactions);

            File.WriteAllText(FilePath, jsonString);
        }

        public async Task<Transaction> GetTransaction(int TransactionId)
        {
            var Transactions = ReadFile();

            var Transaction = Transactions.Find(p => p.Id == TransactionId);

            return Transaction;
        }

        public async Task<IEnumerable<Transaction>> GetTransactions()
        {
            var Transactions = ReadFile();

            return Transactions;
        }

        public async Task UpdateTransaction(Transaction Transaction)
        {
            var Transactions = ReadFile();
            Transactions[Transactions.FindIndex(p => p.Id == Transaction.Id)] = Transaction;

            WriteFile(Transactions);
        }

        public async Task AddTransaction(Transaction Transaction)
        {
            var Transactions = ReadFile();
            Transactions.Add(Transaction);

            WriteFile(Transactions);
        }

        public async Task RemoveSelectedTransaction(Transaction Transaction)
        {
            var Transactions = ReadFile();
            Transactions[Transactions.FindIndex(p => p.Id == Transaction.Id)] = Transaction;
            Transactions.Remove(Transaction);

            WriteFile(Transactions);
        }
    }
}

