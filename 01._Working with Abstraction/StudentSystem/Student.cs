namespace StudentSystem
{
    using System.Text;

    public class Student
    {
        public Student(string name, int age, double grade)
        {
            Name = name;
            Age = age;
            Grade = grade;
        }

        public double Grade { get; set; }

        public int Age { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{Name} is {Age} years old.");

            if (Grade >= 5.00)
            {
                sb.Append(" Excellent student.");
            }
            else if (Grade < 5.00 && Grade >= 3.50)
            {
                sb.Append(" Average student.");
            }
            else
            {
                sb.Append(" Very nice person.");
            }
            return sb.ToString();
        }
    }
}