namespace ParkingSystem.Tests
{
    using System;
    using NUnit.Framework;

    public class SoftParkTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Constructor_Work_Correctly()
        {
            var park = new SoftPark();

            var actualCount = park.Parking.Count;

            Assert.AreEqual(12, actualCount);
        }


        public void Park_Car_Work_Correctly()
        {
            var park = new SoftPark();
            Car car = new Car("Ford", "CA 8484");

            var result = park.ParkCar("A1", car);

            Assert.AreEqual("Car:CA 8484 parked successfully!", result);
        }

        [Test]
        public void Parking_Spot_Doesnt_Exists_Throw()
        {
            var park = new SoftPark();
            Car car = new Car("Ford", "CA 8484");

            Assert.Throws<ArgumentException>((() => park.ParkCar("A0", car)));
        }

        [Test]
        public void Parking_Spot_Is_Already_Taken_Throw()
        {
            var park = new SoftPark();
            Car car = new Car("Ford", "CA 8484");
            Car secondCar = new Car("Opel", "CB 8484");

            park.ParkCar("A1", car);

            Assert.Throws<ArgumentException>(() => park.ParkCar("A1", secondCar));
        }

        [Test]
        public void Car_Is_Already_Parked_Throw()
        {
            var park = new SoftPark();
            Car car = new Car("Ford", "CA 8484");

            park.ParkCar("A1", car);

            Assert.Throws<InvalidOperationException>(() => park.ParkCar("B1", car));
        }

        [Test]
        public void Remove_Car_From_Invalid_Spot_Throw()
        {
            var park = new SoftPark();
            Car car = new Car("Ford", "CA 8484");

            park.ParkCar("A1", car);

            Assert.Throws<ArgumentException>(()=>park.RemoveCar("A0", car));
        }

        [Test]
        public void Remove_Invalid_Car_From_Spot_Throw()
        {
            var park = new SoftPark();
            Car car = new Car("Ford", "CA 8484");

            park.ParkCar("A1", car);

            Assert.Throws<ArgumentException>(() => park.RemoveCar("A2", car));
        }

        [Test]
        public void Remove_Car_Work_Correctly()
        {
            var park = new SoftPark();
            Car car = new Car("Ford", "CA 8484");

            park.ParkCar("A1", car);
            var result = park.RemoveCar("A1", car);

            Assert.AreEqual("Remove car:CA 8484 successfully!", result);
        }
    }
}