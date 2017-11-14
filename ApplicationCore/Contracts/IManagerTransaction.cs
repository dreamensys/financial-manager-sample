using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ApplicationCore.Contracts
{
    [ServiceContract]
    public interface IManagerTransaction
    {
       
        [OperationContract]
        Transaction[] GetTransactions();

        [OperationContract]
        bool CreateNewTransaction(string jsonTransaction);

        [OperationContract]
        bool UpdateTransaction(string jsonTransaction);

        [OperationContract]
        Transaction GetTransactionById(int id);

        [OperationContract]
        bool DeleteTransaction(int id);

    }
   
}
