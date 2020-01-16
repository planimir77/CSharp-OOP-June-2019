using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._The_Final_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfWord = Console.ReadLine().Split().ToList();
            string input = Console.ReadLine();
            while (input != "Stop")
            {
//                  5
//        0 1 2 3 4 5
//- Put { word}{ index} – add a word at the previous place { index} before the given one, if it exists.
//- Sort – you must sort the words in descending order.
//-Replace { word1} { word2} – find the second word { word2} in the collection(if it exists) and replace it with the first word – { word1}.

                List<string> str = input.Split().ToList();
                var command = str[0];
                if (command== "Delete")
                {
                    int index = int.Parse(str[1])+1;
                    if (index >=0 && index<listOfWord.Count)
                    {
                        listOfWord.RemoveAt(index);
                    }
                }
                else if(command == "Sort")
                {
                    listOfWord.Sort();
                    listOfWord.Reverse();
                }
                else if (command == "Swap" && listOfWord.Contains(str[1]) && listOfWord.Contains(str[2]))
                {
                    string word1 = str[1];
                    int index1 = listOfWord.IndexOf(word1);
                    string word2 = str[2];
                    int index2 = listOfWord.IndexOf(word2);
                    listOfWord[index1] = word2;
                    listOfWord[index2] = word1;
                }
                else if (command == "Put")
                {
                    int index = int.Parse(str[2]);
                    string word = str[1];
                    if (index > 0 && index < listOfWord.Count+1)
                    {
                        listOfWord.Insert(index - 1, word);
                    }
                }
                else if (command == "Replace" && listOfWord.Contains(str[2]))
                {
                    string word = str[1];
                    int index = listOfWord.IndexOf(str[2]);
                    listOfWord.Remove(str[2]);
                    listOfWord.Insert(index, word);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(' ',listOfWord));
        }
    }
}
