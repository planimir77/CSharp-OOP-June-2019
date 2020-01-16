using System;
using System.Collections.Generic;
using System.Text;
using _06.BirthdayCelebrations.Interfaces;

namespace _06.BirthdayCelebrations.Model
{
    public class Pet:IPet
    {
        private string _name;
        private string _birthDate;

        public Pet(string name, string birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }
    }
}
