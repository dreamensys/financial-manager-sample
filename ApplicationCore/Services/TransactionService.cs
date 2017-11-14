
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApplicationCore.Services
{
    public class TransactionService : ITransactionService
    {
        private ITransactionRepository repository;

        public TransactionService(ITransactionRepository _repository)
        {
            repository = _repository;
        }
        public IEnumerable<Transaction> GetTransactions()
        {
            return repository.GetTransactions();
        }

        public Transaction GetTransactionById(int id)
        {
            try
            {
                return repository.Get(id);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void Add(Transaction _transaction)
        {
            try
            {
                repository.Add(_transaction);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Transaction _transaction)
        {
            try
            {
                repository.Update(_transaction);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Remove(int id)
        {
            try
            {
                Transaction trn = GetTransactionById(id);
                repository.Remove(trn);
            }
            catch (Exception)
            {

                throw;
            }
        }

       
    }
}
