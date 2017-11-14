using ApplicationCore.Entities;
using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> GetTransactions();
        void Add(Transaction _transaction);
        void Update(Transaction _transaction);
        void Remove(int id);
        Transaction GetTransactionById(int id);
    }
}
