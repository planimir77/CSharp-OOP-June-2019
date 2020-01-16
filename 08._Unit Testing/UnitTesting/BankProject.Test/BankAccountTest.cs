using NUnit.Framework;

namespace BankProject.Tests
{
    [TestFixture]

    public class BankAccountTest
    {
        [Test]

        public void TestNewBankAccount()
        {
            var bankAccount = new BankAccount(100m);

            Assert.That(bankAccount.Balance,Is.EqualTo(100m), "Error message");
        }

        [Test]

        public void TestNewBankAccountWithNewNegativeBalance()
        {
            Assert.That(() => new BankAccount(-100m),Throws.ArgumentException
                .With.Message.EqualTo("Balance can not by negative"));
        }

        [Test]

        public void Deposit()
        {

        }
    }
}
