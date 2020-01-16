using _06.BirthdayCelebrations.Interfaces;

namespace _06.BirthdayCelebrations.Model
{
    public class Citizen:ICitizen, IId, IPet
    {
        private string _name;
        private int _age;
        private string _id;
        private string _birthDate;

        public Citizen(string name, int age, string id, string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
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
