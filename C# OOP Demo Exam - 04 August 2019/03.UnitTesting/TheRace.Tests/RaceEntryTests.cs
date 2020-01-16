namespace TheRace.Tests
{
    using System;
    using NUnit.Framework;

    public class RaceEntryTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Rider_Successfully_Added()
        {
            var race = new RaceEntry();
            var motorcycle = new UnitMotorcycle("Balkan", 40, 100);
            var rider = new UnitRider("Ivan", motorcycle);

            var actual = race.AddRider(rider);

            var expected = "Rider Ivan added in race.";
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(1, race.Counter);
        }

        [Test]
        public void Add_Rider_Throw_InvalidOperationException()
        {
            var race = new RaceEntry();

            Assert.Throws<InvalidOperationException>((() => race.AddRider(null)), "Rider cannot be null.");
        }

        [Test]
        public void Add_Existing_Rider_Throw_InvalidOperationException()
        {
            var race = new RaceEntry();
            var motorcycle = new UnitMotorcycle("Balkan", 40, 100);
            var rider = new UnitRider("Ivan", motorcycle);

            race.AddRider(rider);

            Assert.Throws<InvalidOperationException>((() => race.AddRider(rider)), "Rider Ivan is already added.");
        }

        [Test]
        public void Calculate_Average_HorsePower_Is_Correctly()
        {
            var race = new RaceEntry();
            var motorcycle = new UnitMotorcycle("Balkan", 40, 100);
            var rider = new UnitRider("Ivan", motorcycle);

            var secondMotorcycle = new UnitMotorcycle("Yamaha", 60, 100);
            var secondRider = new UnitRider("John", secondMotorcycle);

            race.AddRider(rider);
            race.AddRider(secondRider);

            var actualAverageHorsePower = race.CalculateAverageHorsePower();

            Assert.AreEqual(50, actualAverageHorsePower);
        }

        [Test]
        public void Invalid_Participants_Throw_InvalidOperationException()
        {
            var race = new RaceEntry();
            var motorcycle = new UnitMotorcycle("Balkan", 40, 100);
            var rider = new UnitRider("Ivan", motorcycle);

            race.AddRider(rider);

            Assert.Throws<InvalidOperationException>((() => race.CalculateAverageHorsePower())
                , "The race cannot start with less than 2 participants.");
        }
    }
}