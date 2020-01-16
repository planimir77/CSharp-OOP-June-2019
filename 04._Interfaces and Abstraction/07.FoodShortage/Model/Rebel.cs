using System;
using System.Collections.Generic;
using System.Text;
using _07.FoodShortage.Interface;

namespace _07.FoodShortage.Model
{
    public class Rebel:IBuyer
    {
        private int _food;
        private string _name;
        private int _age;
        private string _group;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
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

        public string Group
        {
            get { return _group; }
            set { _group = value; }
        }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
