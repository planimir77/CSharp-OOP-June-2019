using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedyTimes
{

    public class Startup
    {
        static void Main()
        {
            long bagCapacity= long.Parse(Console.ReadLine());

            string[] safe= Console.ReadLine()?
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            
            for (int i = 0; i < safe?.Length; i += 2)
            {
                string item = safe[i];
                long quantity = long.Parse(safe[i + 1]);

                string currentItem = string.Empty;

                if (item.Length == 3)
                {
                    currentItem = "Cash";
                }
                else if (item.ToLower().EndsWith("gem"))
                {
                    currentItem = "Gem";
                }
                else if (item.ToLower() == "gold")
                {
                    currentItem = "Gold";
                }

                if (currentItem == "")
                {
                    continue;
                }
                else if (bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + quantity)
                {
                    continue;
                }

                switch (currentItem)
                {
                    case "Gem":
                        if (!bag.ContainsKey(currentItem))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (quantity > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[currentItem].Values.Sum() + quantity > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bag.ContainsKey(currentItem))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (quantity > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[currentItem].Values.Sum() + quantity > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!bag.ContainsKey(currentItem))
                {
                    bag[currentItem] = new Dictionary<string, long>();
                }

                if (!bag[currentItem].ContainsKey(item))
                {
                    bag[currentItem][item] = 0;
                }

                bag[currentItem][item] += quantity;
                
            }

            foreach (var keyValuePair in bag)
            {
                Console.WriteLine($"<{keyValuePair.Key}> ${keyValuePair.Value.Values.Sum()}");
                foreach (var item in keyValuePair.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }
    }
}