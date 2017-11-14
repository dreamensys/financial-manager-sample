using ApplicationCore.Entities;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using ApplicationCore.Interfaces;
using System.Linq;

namespace Infrastructure.Data
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {

        public TransactionRepository(ManagerDBContext context)
            : base(context)
        {
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return ManagerContext.Transactions.ToList();
           
        }

        public void Update(Transaction trn)
        {
            try
            {
                var result = Get(trn.Id);
                if (result != null)
                {
                    result.Step = trn.Step;
                    result.Type = trn.Type;
                    result.Amount = trn.Amount;
                    result.NameOrigin = trn.NameOrigin;
                    result.OldBalanceOrg = trn.OldBalanceOrg;
                    result.NewBalanceOrg = trn.NewBalanceDest;
                    result.NameDest = trn.NameDest;
                    result.OldBalanceDest = trn.OldBalanceDest;
                    result.NewBalanceDest = trn.NewBalanceDest;
                    result.IsFraud = trn.IsFraud;
                    Commit();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
