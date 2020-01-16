namespace Telecom.Tests
{
    using System;
    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void Constructor_Work_Correctly()
        {
            var phone = new Phone("Nokia","3310");

            var make = phone.Make;
            var model = phone.Model;

            Assert.AreEqual("Nokia", make);
            Assert.AreEqual("3310", model);
        }

        [Test]
        public void Invalid_Make_Throw_Exception()
        {
            Phone phone;
            Assert.Throws<ArgumentException>(() => phone = new Phone(null, "3310"));
        }

        [Test]
        public void Invalid_Model_Throw_Exception()
        {
            Phone phone;
            Assert.Throws<ArgumentException>(() => phone = new Phone("Nokia", null));
        }

        [Test]
        public void AddContact_Work_Correctly()
        {
            var phone = new Phone("Nokia", "3310");

            phone.AddContact("Pesho","1234567890");
            var contacts = phone.Count;
            
            Assert.AreEqual(1, contacts);
        }

        [Test]
        public void Add_Existing_Contact_Throw()
        {
            var phone = new Phone("Nokia", "3310");

            phone.AddContact("Pesho", "1234567890");

            Assert.Throws<InvalidOperationException>(() => phone.AddContact("Pesho", "1234567891"));
        }

        [Test]
        public void Call_Work_Correctly()
        {
            var phone = new Phone("Nokia", "3310");

            phone.AddContact("Pesho", "1234567890");
            var callBack = phone.Call("Pesho");
            var expected = "Calling Pesho - 1234567890...";

            Assert.AreEqual(expected, callBack);
        }

        [Test]
        public void Call_Not_Existing_Person_Throw()
        {
            var phone = new Phone("Nokia", "3310");

            phone.AddContact("Pesho", "1234567890");

            Assert.Throws<InvalidOperationException>(()=>phone.Call("Gosho"));
        }

        public void Add_To_Not_Existing_Contact_Throw()
        {
            var phone = new Phone("Nokia", "3310");

            phone.AddContact("Pesho", "1234567890");

            Assert.Throws<InvalidOperationException>(() => phone.Call("Gosho"));
        }
    }
}