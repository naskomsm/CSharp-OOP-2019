namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class Tests
    {
        private Phone phone;

        [SetUp]
        public void SetUp()
        {
            this.phone = new Phone("wat", "s8");
        }

        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            Assert.That("wat", Is.EqualTo(phone.Make));
            Assert.That("s8", Is.EqualTo(phone.Model));
            Assert.That(0, Is.EqualTo(phone.Count));
        }

        [Test]
        public void PropertyMakeShouldWorkCorrectly()
        {
            Assert.That("wat", Is.EqualTo(phone.Make));
        }

        [Test]
        public void PropertyMakeShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Phone(null, "s8"));
        }

        [Test]
        public void PropertyModelShouldWorkCorrectly()
        {
            Assert.That("s8", Is.EqualTo(phone.Model));
        }

        [Test]
        public void PropertyModelShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Phone("wat", null));
        }

        [Test]
        public void MethodAddContactShouldWork()
        {
            this.phone.AddContact("Atanas", "0899115617");
            Assert.That(1, Is.EqualTo(this.phone.Count));
        }

        [Test]
        public void MethodAddContactShouldThrowException()
        {
            this.phone.AddContact("Atanas", "0899115617");
            Assert.Throws<InvalidOperationException>(()=> this.phone.AddContact("Atanas", "0899115617"));
        }

        [Test]
        public void MethodCallShouldWorkCorrectly()
        {
            this.phone.AddContact("Atanas", "0899115617");
            Assert.That("Calling Atanas - 0899115617...", Is.EqualTo(this.phone.Call("Atanas")));
        }

        [Test]
        public void MethodCallShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => this.phone.Call("Atanas"));
        }
    }
}