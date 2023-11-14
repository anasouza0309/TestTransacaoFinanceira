using System;
using TransacaoFinanceira.Application.Transfer.DTO;
using TransacaoFinanceira.Domain.Entities;
using TransacaoFinanceira.Domain.Repositories;
using TransacaoFinanceira.Domain.Util;

namespace TransacaoFinanceira.Domain.Services
{
    public class FinancialOperation
    {

        internal IAccountRepository AccountRepository { get; private set; }
        private readonly NotificationContext notificationContext;

        public FinancialOperation(IAccountRepository accountRepository, NotificationContext notificationContext) 
        {
            this.AccountRepository = accountRepository;
            this.notificationContext = notificationContext;
        }

    
        public Notification transfer(OperationTransfer operationTransfer)
        {
            AccountCurrent sourceAccount = this.AccountRepository.getAmount(operationTransfer.sourceAccountNumber);

            if (sourceAccount.balance > operationTransfer.value)
            {
           
                AccountCurrent targetAccount = this.AccountRepository.getAmount(operationTransfer.targetAccountNumber);
                sourceAccount.balance -= operationTransfer.value;
                targetAccount.balance += operationTransfer.value;
                notificationContext.AddNotification("200", String.Format("Transacao numero {0} foi efetivada com sucesso! Novos saldos: " +
                    "Conta Origem:{1} | Conta Destino: {2}",
                    operationTransfer.correlationId, sourceAccount.balance, targetAccount.balance), sourceAccount);
                Console.WriteLine("Transacao numero {0} foi efetivada com sucesso! Novos saldos: Conta Origem:{1} | Conta Destino: {2}", operationTransfer.correlationId, sourceAccount.balance, targetAccount.balance);

                return notificationContext.GetNotifications();
            }

            notificationContext.AddNotification("500", String.Format("Transacao numero {0 } foi cancelada por falta de saldo", 
                operationTransfer.correlationId), string.Empty);
            Console.WriteLine("Transacao numero {0 } foi cancelada por falta de saldo", operationTransfer.correlationId);
            return notificationContext.GetNotifications();

        }
    }
}
