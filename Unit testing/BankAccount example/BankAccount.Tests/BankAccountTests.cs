using System;
using NUnit.Framework;

namespace BankAccount.Tests
{
    public class Tests
    {
        private BankAccount bankAccount;

        [SetUp]
        public void Setup()
        {
            this.bankAccount = new BankAccount("Atanas", 200);
        }

        [Test]
        public void Constructor_ShouldInitialize_Correctly()
        {
            Assert.That("Atanas", Is.EqualTo(this.bankAccount.Name));
            Assert.That(200, Is.EqualTo(this.bankAccount.Balance));
        }

        [Test]
        public void Constructor_ShouldInitialize_Wrong()
        {
            Assert.That("Kolio", !Is.EqualTo(this.bankAccount.Name));
            Assert.That(520, !Is.EqualTo(this.bankAccount.Balance));
        }

        [Test]
        public void PropertyNameShouldWorkCorrectly()
        {
            Assert.That("Atanas", Is.EqualTo(this.bankAccount.Name));
        }

        [Test]
        [TestCase("")]
        [TestCase("as")]
        [TestCase("asdasdasdadasdasdasdasdasdasdasdasd")]
        public void PropertyNameShouldWorkThrowArgumentException(string test)
        {
            Assert.Throws<ArgumentException>(() => this.bankAccount = new BankAccount(test, 200));
        }

        [Test]
        public void PropertyBalanceShouldWorkCorrectly()
        {
            Assert.That(200, Is.EqualTo(this.bankAccount.Balance));
        }

        [Test]
        public void PropertyBalanceShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => this.bankAccount = new BankAccount("Kolio", -51));
        }

        [Test]
        public void MethodDepositShouldWorkCorrectly()
        {
            this.bankAccount.Deposit(100);
            Assert.That(300, Is.EqualTo(this.bankAccount.Balance));
        }
        
        [Test]
        [TestCase(0)]
        [TestCase(-123)]
        public void MethodDepositShouldThrowInvalidOperationException(int test)
        {
            Assert.Throws<InvalidOperationException>(() => this.bankAccount.Deposit(test));
        }

        [Test]
        public void MethodWithdrawShouldWorkCorrectly()
        {
            this.bankAccount.Withdraw(100);
            Assert.That(100, Is.EqualTo(this.bankAccount.Balance));
        }

        [Test]
        [TestCase(200)]
        [TestCase(201)]
        [TestCase(-1)]
        public void MethodtWithdrawShouldThrowInvalidOperationException(int test)
        {
            Assert.Throws<InvalidOperationException>(() => this.bankAccount.Withdraw(test));
        }
    }
}