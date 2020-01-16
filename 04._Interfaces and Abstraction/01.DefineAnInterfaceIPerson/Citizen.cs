using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen:IPerson, IIdentifiable, IBirthable
    {
        private string _name;
        private int _age;
        private string _id;
        private string _birthdate;

        public Citizen(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public Citizen(string name, int age, string id, string birthdate)
        : this(name, age)
        {
            this.Id = id;
            this.Birthdate = birthdate;
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
    }
}
