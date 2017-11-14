using ApplicationCore.Contracts;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using CrossCutting;
using System.Linq;
using System;
using Newtonsoft.Json;

namespace WebService
{
    public class ManagerService : IManagerTransaction
    {
        public bool CreateNewTransaction(string jsonTransaction)
        {
            Transaction transaction = JsonConvert.DeserializeObject<Transaction>(jsonTransaction);
            var svTransaction = IoCFactory.Resolve<ITransactionService>();
            
            try
            {
                svTransaction.Add(transaction);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteTransaction(int id)
        {
            var svTransaction = IoCFactory.Resolve<ITransactionService>();

            try
            {
                svTransaction.Remove(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Transaction GetTransactionById(int id)
        {
            var svTransaction = IoCFactory.Resolve<ITransactionService>();

            try
            {
                return svTransaction.GetTransactionById(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Transaction[] GetTransactions()
        {
            var svTransaction = IoCFactory.Resolve<ITransactionService>();
            return svTransaction.GetTransactions().ToArray();
        }

        public bool UpdateTransaction(string jsonTransaction)
        {
            var svTransaction = IoCFactory.Resolve<ITransactionService>();
            Transaction transaction = JsonConvert.DeserializeObject<Transaction>(jsonTransaction);
            try
            {
                svTransaction.Update(transaction);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
