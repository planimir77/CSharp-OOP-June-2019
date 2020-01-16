using System;
using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database.Database(new []{1,2});
        }

        [Test]
        public void Test_If_Constructor_Works_Correctly()
        {
            var actualCount = database.Count;
            var expectedCount = 2;

            Assert.AreEqual(expectedCount,actualCount);
        }

        [Test]
        public void Test_If_Adding_Correctly()
        {
            database.Add(4);

            Assert.AreEqual(3, database.Count);
        }

        [Test]
        public void Test_If_Remove_Element()
        {
            database.Remove();

            Assert.AreEqual(1,database.Count);
        }

        [Test]
        public void Test_If_Capacity_Is_Full()
        {
            for (int i = 3; i <= 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>( ()=>
            {
                database.Add(17);
            });
        }

        [Test]
        public void Test_If_Collection_Is_Empty()
        {
            database.Remove();
            database.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [Test]
        public void Test_If_Fetch_Works_Correctly()
        {
            var expected = new int[] {1, 2};
            var actual = database.Fetch();
            CollectionAssert.AreEqual(expected,actual);
        }
    }
}