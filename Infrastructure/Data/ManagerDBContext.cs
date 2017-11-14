using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ManagerDBContext : DbContext
    {
        public ManagerDBContext()
            :base("ManagerDBContext")
        {
        }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
