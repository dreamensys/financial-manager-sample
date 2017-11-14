using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class TransactionViewModel
    {
        public int Id { get; set; }

        [Required]
        public int Step { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public string NameOrigin { get; set; }

        [Required]
        public double OldBalanceOrg { get; set; }

        [Required]
        public double NewBalanceOrg { get; set; }

        [Required]
        public string NameDest { get; set; }

        [Required]
        public double OldBalanceDest { get; set; }

        [Required]
        public double NewBalanceDest { get; set; }

        [Required]
        public bool IsFraud { get; set; }

        [Required]
        public bool IsFlaggedFraud { get; set; }
    }
}