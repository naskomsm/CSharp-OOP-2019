namespace CarTrip.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        private Car car;

        [SetUp]
        public void SetUp()
        {
            this.car = new Car("BMW", 200, 100, 5);
        }

        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            Assert.That("BMW", Is.EqualTo(car.Model));
            Assert.That(200, Is.EqualTo(car.TankCapacity));
            Assert.That(100, Is.EqualTo(car.FuelAmount));
            Assert.That(5, Is.EqualTo(car.FuelConsumptionPerKm));
        }

        [Test]
        public void Constructor_ShouldInitializeWrong()
        {
            Assert.That("asd", !Is.EqualTo(car.Model));
            Assert.That(1234, !Is.EqualTo(car.TankCapacity));
            Assert.That(1, !Is.EqualTo(car.FuelAmount));
            Assert.That(4, !Is.EqualTo(car.FuelConsumptionPerKm));
        }

        [Test]
        public void PropertyModelShouldWorkCorrectly()
        {
            Assert.That("BMW", Is.EqualTo(car.Model));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void PropertyModelShouldThrowArgumentException(string test)
        {
            Assert.Throws<ArgumentException>(() => new Car(test, 200, 100, 5));
        }

        [Test]
        public void PropertyFuelAmountShouldWorkCorrectly()
        {
            Assert.That(100, Is.EqualTo(car.FuelAmount));
        }

        [Test]
        [TestCase(500)]
        [TestCase(201)]
        public void PropertyFuelAmountShouldThrowArgumentException(double test)
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", 200, test, 5));
        }

        [Test]
        public void PropertyFuelConsumptionShouldWorkCorrectly()
        {
            Assert.That(5, Is.EqualTo(car.FuelConsumptionPerKm));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-15)]
        public void PropertyFuelConsumptionShouldThrowArgumentException(double test)
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", 200, 100, test));
        }

        [Test]
        public void MethodDriveShouldWorkCorrectly()
        {
            Assert.That("Have a nice trip", Is.EqualTo(this.car.Drive(2)));
            Assert.That(90, Is.EqualTo(this.car.FuelAmount));
        }

        [Test]
        [TestCase(500)]
        [TestCase(50)]
        public void MethodDriveShouldThrowInvalidOperationException(double test)
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(test));
        }

        [Test]
        [TestCase(70)]
        [TestCase(100)]
        public void MethodRefuelShouldWorkCorrectly(double test)
        {
            this.car.Refuel(test);
            Assert.That(100+test, Is.EqualTo(this.car.FuelAmount));
        }

        [Test]
        public void MethodRefuelShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Refuel(150));
        }
    }
}