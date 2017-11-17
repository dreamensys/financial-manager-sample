using ApplicationCore.Contracts;
using ApplicationCore.Interfaces;
using CrossCutting;
using System.Linq;
using System;
using Newtonsoft.Json;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;

namespace WebService
{
    public class ManagerService : IManagerTransaction
    {
        public bool CreateNewTransaction(string jsonTransactionDTO)
        {
            TransactionDTO trnDTO = JsonConvert.DeserializeObject<TransactionDTO>(jsonTransactionDTO);
            var svTransaction = IoCFactory.Resolve<ITransactionService>();
            
            try
            {
                var transaction = ToTransactionModel(trnDTO);
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

        public TransactionDTO GetTransactionById(int id)
        {
            var svTransaction = IoCFactory.Resolve<ITransactionService>();

            try
            {
                var trn = svTransaction.GetTransactionById(id);
                return new TransactionDTO()
                {
                    Id = trn.Id,
                    Step = trn.Step,
                    Type = trn.Type,
                    Amount = trn.Amount,
                    NameOrigin = trn.NameOrigin,
                    OldBalanceOrg = trn.OldBalanceOrg,
                    NewBalanceOrg = trn.NewBalanceDest,
                    NameDest = trn.NameDest,
                    OldBalanceDest = trn.OldBalanceDest,
                    NewBalanceDest = trn.NewBalanceDest,
                    IsFraud = trn.IsFraud
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        public TransactionDTO[] GetTransactions()
        {
            var svTransaction = IoCFactory.Resolve<ITransactionService>();
            return svTransaction.GetTransactions().Select( trn=> new TransactionDTO() {
                Id = trn.Id,
                Step = trn.Step,
                Type = trn.Type,
                Amount = trn.Amount,
                NameOrigin = trn.NameOrigin,
                OldBalanceOrg = trn.OldBalanceOrg,
                NewBalanceOrg = trn.NewBalanceDest,
                NameDest = trn.NameDest,
                OldBalanceDest = trn.OldBalanceDest,
                NewBalanceDest = trn.NewBalanceDest,
                IsFraud = trn.IsFraud
            }).ToArray();
        }

        public bool UpdateTransaction(string jsonTransactionDTO)
        {
            var svTransaction = IoCFactory.Resolve<ITransactionService>();
            TransactionDTO trnDTO = JsonConvert.DeserializeObject<TransactionDTO>(jsonTransactionDTO);
            try
            {
                var transaction = ToTransactionModel(trnDTO);
                svTransaction.Update(transaction);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private Transaction ToTransactionModel(TransactionDTO trn)
        {
            return new Transaction() {
                Id = trn.Id,
                Step = trn.Step,
                Type = trn.Type,
                Amount = trn.Amount,
                NameOrigin = trn.NameOrigin,
                OldBalanceOrg = trn.OldBalanceOrg,
                NewBalanceOrg = trn.NewBalanceDest,
                NameDest = trn.NameDest,
                OldBalanceDest = trn.OldBalanceDest,
                NewBalanceDest = trn.NewBalanceDest,
                IsFraud = trn.IsFraud
            };
        }

    }
}
