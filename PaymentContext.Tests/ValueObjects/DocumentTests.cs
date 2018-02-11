using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var doc = new Document("92484057000121", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("123")]
        [DataRow("A9579692068")]
        [DataRow("@6133706066")]
        public void ShouldReturnErrorWhenCPFIsInvalid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("57678623038")]
        [DataRow("59579692068")]
        [DataRow("66133706066")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }
    }
}
