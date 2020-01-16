using _05.BorderControl.Interfaces;

namespace _05.BorderControl.Model
{
    public class Robot : IRobot, IId
    {
        private string _id;
        private string _model;


        public Robot(string id, string model)
        {
            this.Id = id;
            this.Model = model;
        }
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }
    }
}
