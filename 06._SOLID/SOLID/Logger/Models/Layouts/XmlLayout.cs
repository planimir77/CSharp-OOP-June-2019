using System.Text;
using Logger.Models.Contracts;

namespace Logger.Models.Layouts
{
    public class XmlLayout:ILayout
    {

        public string Format
        {
            get { return GetFormat(); }
        }

        private string GetFormat()
        {
            var result = new StringBuilder();
            result.AppendLine("<log>")
                .AppendLine("\t<date>{0}</date>")
                .AppendLine("\t<level>{1}</level>")
                .AppendLine("\t<message>{2}</message>")
                .AppendLine("</log>");

            return result.ToString().TrimEnd();
        }
    }
}
