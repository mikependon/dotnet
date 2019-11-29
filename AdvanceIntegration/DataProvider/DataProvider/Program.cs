using DataProvider.Models;
using DataProvider.Repositories;
using RepoDb;
using RepoDb.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var messages = GetMessages(count)
                .AsList();

            using (var repository = new MessageRepository())
            {
                var startTime = DateTime.UtcNow;
                var deleteAllResult = repository.DeleteAll();

                Console.WriteLine($"Truncated the table. " +
                    $"Elapsed: { (DateTime.UtcNow - startTime).TotalSeconds } second(s).");

                startTime = DateTime.UtcNow;
                var bulkInsertResult = repository.BulkInsert(messages);
                Console.WriteLine($"{bulkInsertResult} message(s) has been inserted. " +
                    $"Elapsed: { (DateTime.UtcNow - startTime).TotalSeconds } second(s).");
            }
        }

        private static IEnumerable<Message> GetMessages(int count)
        {
            var strings = GetStrings().AsList();
            for (var i = 0; i < count; i++)
            {
                var index = new Random().Next(0, strings.Count - 1);
                yield return new Message
                {
                    Body = strings[index]
                };
            }
        }

        private static IEnumerable<string> GetStrings()
        {
            var text = @"We believe that it's time to take real action to create a world that runs on green energy. Renewable energy holds the key to a cleaner future, and we need to act now to reduce the effects of climate change.";
            return text.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s?.Trim())
                .Where(s => s?.Length > 0)
                .AsEnumerable();
        }
    }
}
