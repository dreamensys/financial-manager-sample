using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FinancialManagerSystem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ManagerService : IManagerService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public Transaction[] GetTransactions()
        {
            var list = new Transaction[5];
            list[0] = new Transaction() { Id = 1, NameOrigin = "Ori1", Amount = 100 };
            list[1] = new Transaction() { Id = 2, NameOrigin = "Ori2", Amount = 200 };
            list[2] = new Transaction() { Id = 3, NameOrigin = "Ori3", Amount = 300 };
            list[3] = new Transaction() { Id = 4, NameOrigin = "Ori4", Amount = 400 };
            list[4] = new Transaction() { Id = 5, NameOrigin = "Ori5", Amount = 500 };
            return list;
        }


    }
}
