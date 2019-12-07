using DataProvider.Factories;
using DataProvider.Processor;
using RepoDb.Extensions;
using System;

namespace DataProvider
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Number of Messages: ");
                var count = Convert.ToInt32(Console.ReadLine());
                Process(count);
                Console.WriteLine("");
            }
        }

        private static void Process(int count)
        {
            var messages = MessageFactory.GetMessages(count).AsList();
            var processor = new MessageDataProcessor();
            var startTime = DateTime.UtcNow;
            var result = processor.ProcessAsync(messages);
            Console.WriteLine($"{count} message(s) has been published. " +
                $"Elapsed: { (DateTime.UtcNow - startTime).TotalSeconds } second(s).");
        }
    }
}
