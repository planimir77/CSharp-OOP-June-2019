namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private Spaceship spaceship;
        private Astronaut astronaut;
        private Astronaut astronaut2;
        private Astronaut astronaut3;

        [SetUp]
        public void SetUp()
        {
            astronaut = new Astronaut("Gosho", 3.2);
            astronaut2 = new Astronaut("Pesho", 2.2);
            astronaut3 = new Astronaut("Tosho", 2);
            spaceship = new Spaceship("Indevar", 2);
        }

        [Test]
        public void Constructor_Work_Correctly()
        {
            var name = spaceship.Name;
            var capacity = spaceship.Capacity;
            var astronautName = astronaut.Name;
            var astronautOxygenInPercentage = astronaut.OxygenInPercentage;

            Assert.AreEqual("Indevar", name);
            Assert.AreEqual(2, capacity);
            Assert.AreEqual(0, spaceship.Count);
            Assert.AreEqual("Gosho", astronautName);
            Assert.AreEqual(3.2, astronautOxygenInPercentage);
        }

        [Test]
        public void Invalid_Name_Throw_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(null, 2));
        }

        [Test]
        public void Empty_Name_Throw_Exception()
        {
            
            Assert.Throws<ArgumentNullException>(() => new Spaceship("", 2));
        }

        [Test]
        public void Invalid_Capacity_Throw_Exception()
        {
            Assert.Throws<ArgumentException>(() => new Spaceship("Mir", -1));
        }

        [Test]
        public void Add_Astronaut_Work_Correctly()
        {
            spaceship.Add(astronaut);
            spaceship.Add(astronaut2);

            var count = spaceship.Count;

            Assert.AreEqual(2,count);
        }

        [Test]
        public void Spaceship_Is_Full_Throw_Exception()
        {
            spaceship.Add(astronaut);
            spaceship.Add(astronaut2);

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut3));
        }

        [Test]
        public void Already_Exist_Astronaut_Throw_Exception()
        {
            spaceship.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut));
        }

        [Test]
        public void Remove_Astronaut_Work_Correctly()
        {
            spaceship.Add(astronaut);
            spaceship.Add(astronaut2);
            var isRemove = spaceship.Remove("Gosho");

            Assert.AreEqual(true,isRemove);
        }

        [Test]
        public void Remove_Invalid_Astronaut_Work_Correctly()
        {
            spaceship.Add(astronaut2);
            var isRemove = spaceship.Remove("Gosho");


            Assert.AreEqual(false, isRemove);
        }
    }
}