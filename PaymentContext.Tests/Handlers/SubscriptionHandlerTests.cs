using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Bruce";
            command.LastName = "Wayne";
            command.Document = "99999999999";
            command.Email = "teste@teste.com";
            command.Barcode = "123456789";
            command.BoletoNumber = "1323146546";
            command.PaymentNumber = "1231321";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Wayne Corp";
            command.PayerEmail = "batman@dc.com";
            command.PayerDocument = "";
            command.PayerDocumentType = EDocumentType.CPF;
            command.Street = "asdasd";
            command.Number = "234";
            command.Neighborhood = "asdasd";
            command.City = "asdasd";
            command.State = "asdasd";
            command.Country = "asdasd";
            command.ZipCode = "51236548";

            var commandResult = handler.Handle(command);

            //Assert.AreEqual(false, handler.Valid);
            Assert.AreEqual(false, commandResult.Success);
        }
    }
}
