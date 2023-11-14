using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransacaoFinanceira.Domain.Entities
{
    public class AccountCurrent
    {
        public AccountCurrent(Int64 accountNumber, decimal value)
        {
            this.accountNumber = accountNumber;
            this.balance = value;
        }
        public Int64 accountNumber { get; set; }
        public decimal balance { get; set; }
    }
}
