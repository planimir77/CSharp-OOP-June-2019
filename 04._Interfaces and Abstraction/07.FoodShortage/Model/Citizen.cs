using System;
using System.Collections.Generic;
using System.Text;
using _07.FoodShortage.Interface;

namespace _07.FoodShortage.Model
{
    class Citizen:IBuyer
    {
        private int _food;
        private string _name;
        private int _age;
        private string _id;
        private string _birthdate;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public int Food
        {
            get { return _food; }
            set { _food = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Birthdate
        {
            get { return _birthdate; }
            set { _birthdate = value; }
        }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
