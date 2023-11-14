using System.Collections.Generic;
using TransacaoFinanceira.Domain.Entities;

namespace TransacaoFinanceira.Infra.Data
{
    public class DBContext
    {
        Dictionary<int, decimal> AMOUNT { get; set; }
        private static List<AccountCurrent> AMOUNT_TABLE;

        public DBContext()
        {
            AMOUNT_TABLE = new List<AccountCurrent>();
            AMOUNT_TABLE.Add(new AccountCurrent(938485762, 180));
            AMOUNT_TABLE.Add(new AccountCurrent(347586970, 1200));
            AMOUNT_TABLE.Add(new AccountCurrent(2147483649, 0));
            AMOUNT_TABLE.Add(new AccountCurrent(675869708, 4900));
            AMOUNT_TABLE.Add(new AccountCurrent(238596054, 478));
            AMOUNT_TABLE.Add(new AccountCurrent(573659065, 787));
            AMOUNT_TABLE.Add(new AccountCurrent(210385733, 10));
            AMOUNT_TABLE.Add(new AccountCurrent(674038564, 400));
            AMOUNT_TABLE.Add(new AccountCurrent(563856300, 1200));
                    
        }

        public static List<AccountCurrent> getAmountTable()
        {
            return AMOUNT_TABLE;
        }

    }
}
