using System;
using System.Linq;
using ExtendedDatabase;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase database;
        private Person[] persons;
        private Person person;

        [SetUp]
        public void Setup()
        {
            persons = new Person[17];

            for (int i = 0; i < 17; i++)
            {
                long id = 12345678 + i;

                persons[i] = new Person(id, $"Gosho_{i}");
            }
        }

        [Test]
        public void Test_If_Constructor_Works_Correctly()
        {
            var currentPersons = persons.Take(2).ToArray();
            database = new ExtendedDatabase.ExtendedDatabase(currentPersons);

            Assert.IsNotNull(database);
        }

        [Test]
        public void Test_Adding_Range_Works_Correctly()
        {
            var currentPersons = persons.Take(2).ToArray();
            database = new ExtendedDatabase.ExtendedDatabase(currentPersons);

            Assert.AreEqual(2, database.Count);
        }

        [Test]
        public void Test_Add_Person_Works_Correctly()
        {
            var currentPersons = persons.Take(2).ToArray();
            database = new ExtendedDatabase.ExtendedDatabase(currentPersons);

            person = new Person(1234656890, "Pesho");
            database.Add(person);

            Assert.AreEqual(3, database.Count);
        }

        [Test]
        public void Test_Person_Capacity_Is_Not_Correctly()
        {
            var currentPersons = persons.Take(16).ToArray();
            database = new ExtendedDatabase.ExtendedDatabase(currentPersons);

            person = new Person(12346568, "Pesho");

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(person);
            });
        }

        [Test]
        public void Test_User_with_This_Username_Already_Exist()
        {
            var currentPersons = persons.Take(15).ToArray();
            database = new ExtendedDatabase.ExtendedDatabase(currentPersons);

            person = new Person(12345678123,"Gosho_0");

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(person);
            });
        }

        [Test]
        public void Test_User_With_This_Id_Already_Exist()
        {
            var currentPersons = persons.Take(15).ToArray();
            database = new ExtendedDatabase.ExtendedDatabase(currentPersons);

            person = new Person(12345678, "Gosho_12345");

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(person);
            });
        }

        [Test]
        public void Test_Remove_From_Empty_Collection()
        {
            var currentPersons = persons.Take(1).ToArray();
            database = new ExtendedDatabase.ExtendedDatabase(currentPersons);
            database.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [Test]
        public void Test_Find_By_Username_Works_Correctly()
        {
            var currentPersons = persons.Take(16).ToArray();
            database = new ExtendedDatabase.ExtendedDatabase(currentPersons);

            Person expectedPerson = new Person(12345678, "Gosho_0");
            
            Person result = database.FindByUsername("Gosho_0");

            Assert.AreEqual(expectedPerson.UserName, result.UserName);
        }

        [Test]
        public void Test_Find_By_Username_Parameter_Is_Null()
        {
            var currentPersons = persons.Take(16).ToArray();
            database = new ExtendedDatabase.ExtendedDatabase(currentPersons);

            Person expectedPerson = new Person(12345678, "Gosho_0");

            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(null);
            });
        }

        [Test]
        public void Test_No_User_With_This_Username()
        {
            var currentPersons = persons.Take(16).ToArray();
            database = new ExtendedDatabase.ExtendedDatabase(currentPersons);

            Person expectedPerson = new Person(123456787644, "Gosho_076574");

            
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername(expectedPerson.UserName);
            });
        }

        [Test]
        public void Test_Find_By_Id_Works_Correctly()
        {
            var currentPersons = persons.Take(16).ToArray();
            database = new ExtendedDatabase.ExtendedDatabase(currentPersons);

            Person expectedPerson = new Person(12345678, "Gosho_0");

            Person result = database.FindById(12345678);

            Assert.AreEqual(expectedPerson.UserName, result.UserName);
        }

        [Test]
        public void Test_Id_Should_Be_A_Positive_Number()
        {
            var currentPersons = persons.Take(16).ToArray();
            database = new ExtendedDatabase.ExtendedDatabase(currentPersons);

            Person expectedPerson = new Person(12345678, "Gosho_0");

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(-1);
            });
        }

        [Test]
        public void Test_No_User_With_This_Id()
        {
            var currentPersons = persons.Take(16).ToArray();
            database = new ExtendedDatabase.ExtendedDatabase(currentPersons);

            Person expectedPerson = new Person(123456787644, "Gosho_076574");


            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(expectedPerson.Id);
            });
        }

        [Test]
        public void Test_Added_Range_Length_Is_Not_Correctly()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                database = new ExtendedDatabase.ExtendedDatabase(persons);
            });
        }
    }


}