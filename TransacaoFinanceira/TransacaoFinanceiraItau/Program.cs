using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransacaoFinanceira.Application.Transfer.DTO;
using TransacaoFinanceira.Domain.Repositories;
using TransacaoFinanceira.Domain.Services;
using TransacaoFinanceira.Domain.Util;
using TransacaoFinanceira.Infra.Data.Repositories;


//Obs: Voce é livre para implementar na linguagem de sua preferência, desde que respeite as funcionalidades e saídas existentes, além de aplicar os conceitos solicitados.

namespace TransacaoFinanceira
{
    class Program
    {

        static void Main(string[] args)
        {
            IAccountRepository accountRepository = new AccountRepository();
            var TRANSACOES = new[] { new OperationTransfer(){correlationId= 1,date=Convert.ToDateTime("09/09/2023 14:15:00"), sourceAccountNumber= 938485762, targetAccountNumber= 2147483649, value= 150},
                                     new OperationTransfer(){correlationId= 2,date=Convert.ToDateTime("09/09/2023 14:15:05"), sourceAccountNumber= 2147483649, targetAccountNumber= 210385733, value= 149},
                                     new OperationTransfer(){correlationId= 3,date=Convert.ToDateTime("09/09/2023 14:15:29"), sourceAccountNumber= 347586970, targetAccountNumber= 238596054, value= 1100},
                                     new OperationTransfer(){correlationId= 4,date=Convert.ToDateTime("09/09/2023 14:17:00"), sourceAccountNumber= 675869708, targetAccountNumber= 210385733, value= 5300},
                                     new OperationTransfer(){correlationId= 5,date=Convert.ToDateTime("09/09/2023 14:18:00"), sourceAccountNumber= 238596054, targetAccountNumber= 674038564, value= 1489},
                                     new OperationTransfer(){correlationId= 6,date=Convert.ToDateTime("09/09/2023 14:18:20"), sourceAccountNumber= 573659065, targetAccountNumber= 563856300, value= 49},
                                     new OperationTransfer(){correlationId= 7,date=Convert.ToDateTime("09/09/2023 14:19:00"), sourceAccountNumber= 938485762, targetAccountNumber= 2147483649, value= 44},
                                     new OperationTransfer(){correlationId= 8,date=Convert.ToDateTime("09/09/2023 14:19:01"), sourceAccountNumber= 573659065, targetAccountNumber= 675869708, value= 150},

            };

            FinancialOperation financialOperation = new FinancialOperation(accountRepository, new NotificationContext());
            Parallel.ForEach(TRANSACOES, item =>
            {
                financialOperation.transfer(item);
            });

        }
    }


}
