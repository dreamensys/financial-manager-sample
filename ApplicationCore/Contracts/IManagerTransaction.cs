using ApplicationCore.DTOs;
using System.ServiceModel;

namespace ApplicationCore.Contracts
{
    [ServiceContract]
    public interface IManagerTransaction
    {
       
        [OperationContract]
        TransactionDTO[] GetTransactions();

        [OperationContract]
        bool CreateNewTransaction(string jsonTransaction);

        [OperationContract]
        bool UpdateTransaction(string jsonTransaction);

        [OperationContract]
        TransactionDTO GetTransactionById(int id);

        [OperationContract]
        bool DeleteTransaction(int id);

    }
   
}
