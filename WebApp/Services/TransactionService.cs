
using ApplicationCore.Contracts;
using ApplicationCore.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WebApp.Helpers;
using WebApp.Models;

namespace WebApp.Services
{
    public class WebTransactionService
    {
        string endpointURl = ConfigurationManager.AppSettings["APIUri"];
        IManagerTransaction client;

        public WebTransactionService()
        {
            client = WCFHelper.CreateServiceClient<IManagerTransaction>(endpointURl);
        }
        public IEnumerable<TransactionViewModel> GetTransactions()
        {
            return client.GetTransactions().Select(trn => new TransactionViewModel()
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
    });
        }

        public bool DeleteTransaction(int id)
        {
            try
            {
                client.DeleteTransaction(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public TransactionViewModel GetTransactionById(int id)
        {
            try
            {
                var trn = client.GetTransactionById(id);
                return new TransactionViewModel() {
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

        public bool CreateNewTransaction(TransactionViewModel trn)
        {
            TransactionDTO transaction = new TransactionDTO()
            {
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

            string transationSerialized = JsonConvert.SerializeObject(transaction);
             
            try
            {
                client.CreateNewTransaction(transationSerialized);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



        public bool UpdateTransaction(TransactionViewModel trn)
        {
            TransactionDTO transaction = new TransactionDTO()
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

            string transationSerialized = JsonConvert.SerializeObject(transaction);
            try
            {
                client.UpdateTransaction(transationSerialized);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}