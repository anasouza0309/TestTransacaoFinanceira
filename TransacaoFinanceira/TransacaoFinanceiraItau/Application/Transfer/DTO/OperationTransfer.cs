using System;

namespace TransacaoFinanceira.Application.Transfer.DTO
{
    public class OperationTransfer
    {

        public Int64 correlationId { get; set; }

        public DateTime date { get; set; }

        public Int64 sourceAccountNumber { get; set; }

        public Int64 targetAccountNumber { get; set; }

        public decimal value { get; set; }


    }
}
