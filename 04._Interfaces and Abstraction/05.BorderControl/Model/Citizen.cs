using System;
using System.Collections.Generic;
using System.Text;
using _05.BorderControl.Interfaces;

namespace _05.BorderControl.Model
{
    class Citizen:ICitizen, IId
    {
        private string _name;
        private int _age;
        private string _id;

        public Citizen(string id, string name, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
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
    }
}
