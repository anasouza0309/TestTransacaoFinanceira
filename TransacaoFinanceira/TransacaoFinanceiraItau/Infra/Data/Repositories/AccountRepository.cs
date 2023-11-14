using TransacaoFinanceira.Domain;
using TransacaoFinanceira.Domain.Entities;
using TransacaoFinanceira.Domain.Repositories;

namespace TransacaoFinanceira.Infra.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public AccountRepository() => new DBContext();

        public void update(AccountCurrent account)
        {
            DBContext.getAmountTable().RemoveAll(x => x.accountNumber == account.accountNumber);
            DBContext.getAmountTable().Add(account);
        }

 
        public AccountCurrent getAmount(long accountNumber)
        {
            return DBContext.getAmountTable()
                .Find(x => x.accountNumber == accountNumber);
        }
    }
}
