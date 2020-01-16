using System;
using System.Collections.Generic;

using Logger.Core;
using Logger.Factories;
using Logger.Models.Contracts;

namespace Logger
{
    
    public class StartUp
    {
        static void Main()
        {
            var numberOfApenders = int.Parse(Console.ReadLine());
            ICollection<IAppender> appenders = new List<IAppender>();
            AppenderFactory apenderFactory = new AppenderFactory();

            ReadAppendersData(numberOfApenders, appenders, apenderFactory);

            ILogger logger = new Models.Logger(appenders);

            var engine = new Engine(logger);

            engine.Run();

        }

        private static void ReadAppendersData(int numberOfApenders, 
                                              ICollection<IAppender> appenders, 
                                              AppenderFactory appenderFactory)
        {
            for (int i = 0; i < numberOfApenders; i++)
            {
                string[] appendersInfo = Console.ReadLine()
                    .Split(" ");

                string appendersType = appendersInfo[0];
                string layoutType = appendersInfo[1];
                string levelStr = "INFO";
                if (appendersInfo.Length == 3)
                {
                    levelStr = appendersInfo[2];
                }
                

                try
                {
                    IAppender appender = appenderFactory.GetAppender
                    (appendersType, layoutType, levelStr);
                    appenders.Add(appender);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }  
            }
        }
    }
}
