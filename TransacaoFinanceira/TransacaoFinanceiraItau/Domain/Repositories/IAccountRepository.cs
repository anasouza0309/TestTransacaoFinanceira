using System;
using TransacaoFinanceira.Domain.Entities;

namespace TransacaoFinanceira.Domain.Repositories
{
    public interface IAccountRepository
    {
        void update(AccountCurrent current);

        AccountCurrent getAmount(Int64 accountNumber);
    }
}
