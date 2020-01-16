using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = "apple,orange,banana";
            Console.WriteLine("Found orange in position: " + fruit.IndexOf("ppl"));
            Console.WriteLine("Found lemon in position: " + fruit.IndexOf("lemon"));
            //for (int i = 0; i <= fullString.Length; i++)
            //{
            //    Console.WriteLine(fullString.Substring(fullString.Length-i));
            //}
            //Console.WriteLine(partOfString);
            //Console.WriteLine(shorterPart);
        }
    }
}
