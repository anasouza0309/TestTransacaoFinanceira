using NUnit.Framework;
using TransacaoFinanceira.Application.Transfer.DTO;
using System;
using TransacaoFinanceira.Domain.Services;
using TransacaoFinanceira.Infra.Data.Repositories;
using TransacaoFinanceira.Domain.Entities;

namespace TestTranscaoFinanceira
{
    public class Tests
    {

        private FinancialOperation _financialOperation;


        [SetUp]
        public void Setup()
        {
            _financialOperation = new FinancialOperation(new AccountRepository(), 
                new TransacaoFinanceira.Domain.Util.NotificationContext());
        }


        [Test]
        public void Transfer_Should_Be_Success_Return_200_As_Sucess_Message()
        {
            OperationTransfer operationTransfer = new OperationTransfer();
            operationTransfer.correlationId = 1;
            operationTransfer.date = Convert.ToDateTime("09/09/2023 14:15:00");
            operationTransfer.sourceAccountNumber = 938485762;
            operationTransfer.targetAccountNumber = 2147483649;
            var result = _financialOperation.transfer(operationTransfer);

            Assert.AreEqual(result.Key, "200");
        }

        [Test]
        public void Transfer_ShouldBe_Debit_100_Reais_From_Source_Account_And_Left_80_Reais()
        {
            OperationTransfer operationTransfer = new OperationTransfer();
            operationTransfer.correlationId = 1;
            operationTransfer.date = Convert.ToDateTime("09/09/2023 14:15:00");
            operationTransfer.sourceAccountNumber = 938485762;
            operationTransfer.targetAccountNumber = 2147483649;
            operationTransfer.value = 100;
            var result = _financialOperation.transfer(operationTransfer);
                   

            Assert.AreEqual(((AccountCurrent)result.Data).balance, 80);
        }


        [Test]
        public void Transfer_ShouldBe_Debit_Twice_Without_Balance_Without_Finalize_The_Transaction()
        {
            OperationTransfer operationTransfer = new OperationTransfer();
            operationTransfer.correlationId = 1;
            operationTransfer.date = Convert.ToDateTime("09/09/2023 14:15:00");
            operationTransfer.sourceAccountNumber = 938485762;
            operationTransfer.targetAccountNumber = 2147483649;
            operationTransfer.value = 100;
            var result = _financialOperation.transfer(operationTransfer);

            Assert.AreEqual(((AccountCurrent)result.Data).balance, 80);

            var result2 = _financialOperation.transfer(operationTransfer);

            Assert.AreEqual(((AccountCurrent)result.Data).balance, 80);


        }



        [Test]
        public void Transfer_ShouldBe_Return_Error_Notification_When_The_Value_IsGreather_Than_Balance()
        {
            OperationTransfer operationTransfer = new OperationTransfer();
            operationTransfer.correlationId = 1;
            operationTransfer.date = Convert.ToDateTime("09/09/2023 14:15:00");
            operationTransfer.sourceAccountNumber = 938485762;
            operationTransfer.targetAccountNumber = 2147483649;
            operationTransfer.value = 200;
            var result = _financialOperation.transfer(operationTransfer);


            Assert.AreEqual(result.Key, "500");
        }

        /*[Test]
        public void Transfer_Should_Be_Success_200()
        {
            OperationTransfer operationTransfer = new OperationTransfer();
            operationTransfer.correlationId = 1;
            operationTransfer.date = Convert.ToDateTime("09/09/2023 14:15:00");
            operationTransfer.sourceAccountNumber = 938485762;
            operationTransfer.targetAccountNumber = 2147483649;
            var result = _financialOperation.transfer(operationTransfer);

            Assert.AreEqual(result.Key, "200");
        }*/
    }
}