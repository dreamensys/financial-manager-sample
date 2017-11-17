using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public int Step { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public string NameOrigin { get; set; }
        public double OldBalanceOrg { get; set; }
        public double NewBalanceOrg { get; set; }
        public string NameDest { get; set; }
        public double OldBalanceDest { get; set; }
        public double NewBalanceDest { get; set; }
        public bool IsFraud { get; set; }
        public bool IsFlaggedFraud { get; set; }
    }
}
