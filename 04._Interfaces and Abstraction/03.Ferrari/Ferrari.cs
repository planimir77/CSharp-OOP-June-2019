using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Ferrari
{
    class Ferrari:ICar
    {
        private string _model;
        private string _driver;

        public Ferrari(string driver)
        {
            this.Driver = driver;
            this.Model = "488-Spider";
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public string Driver
        {
            get { return _driver; }
            set { _driver = value; }
        }

        public string Brakes()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.Brakes()}/{this.Gas()}/{this.Driver}";
        }
    }
}
