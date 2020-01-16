using Logger.Models.Contracts;

namespace Logger.Models.Layouts
{
    public class SimpleLayout:ILayout
    {

        public string Format
        {
            get { return "{0} - {1} - {2}"; }
        }
    }
}
