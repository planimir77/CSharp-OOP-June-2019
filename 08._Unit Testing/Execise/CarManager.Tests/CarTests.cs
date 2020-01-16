using System;
//using CarManager;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {

        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Opel", "Corsa", 10, 50);
        }

        [Test]
        public void Test_Constructor_Works_Correctly()
        {
            Assert.AreEqual(0, car.FuelAmount);
            Assert.AreEqual("Opel", car.Make);
            Assert.AreEqual("Corsa", car.Model);
            Assert.AreEqual(10, car.FuelConsumption);
            Assert.AreEqual(50, car.FuelCapacity);
        }


        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Test_Make_Is_Null_Or_Empty_Throw_Exception(string make)
        {
            Assert.Throws<ArgumentException>((() =>
                    car = new Car(make, "Corsa", 10, 50))
                , "Make cannot be null or empty!");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Test_Model_Is_Null_Or_Empty_Throw_Exception(string model)
        {
            Assert.Throws<ArgumentException>((() =>
                    car = new Car("Opel", model, 10, 50))
                , "Model cannot be null or empty!");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1.2)]
        public void Test_Fuel_Consumption_Is_Zero_Or_Negative_Throw_Exception(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>((() =>
                    car = new Car("Opel", "Corsa", fuelConsumption, 50))
                , "Fuel consumption cannot be zero or negative!");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1.1)]
        public void Test_Fuel_Capacity_Is_Zero_Or_Negative_Throw_Exception(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>((() =>
                    car = new Car("Opel", "Corsa", 10, fuelCapacity))
                , "Fuel capacity cannot be zero or negative!");
        }

        [Test]
        [TestCase(10.1, 10.1)]
        [TestCase(60, 50)]
        public void Test_Fuel_To_Refuel_Works_Correctly(double fuelToRefuel, double expectedFuel)
        {
            car.Refuel(fuelToRefuel);
            Assert.AreEqual(expectedFuel, car.FuelAmount);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1.2)]
        [TestCase(-2)]
        public void Test_Fuel_To_Refuel_Is_Zero_Or_Negative_Throw_Exception(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel)
                , "Fuel amount cannot be zero or negative!");
        }

        [Test]
        [TestCase(100)]
        public void Test_Drive_Works_Correctly(double distance)
        {
            car.Refuel(15);
            car.Drive(distance);
            Assert.AreEqual(5, car.FuelAmount);
        }

        [Test]
        [TestCase(101)]
        public void Test_Drive_With_Negative_Value(double distance)
        {
            car.Refuel(10);
            Assert.Throws<InvalidOperationException>(() =>
                car.Drive(distance)
                , "You don't have enough fuel to drive!");
        }
    }
}