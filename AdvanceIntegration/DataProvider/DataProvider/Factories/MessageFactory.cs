using DataProvider.Models;
using RepoDb.Extensions;
using System;
using System.Collections.Generic;

namespace DataProvider.Factories
{
    public static class MessageFactory
    {
        public static IEnumerable<Message> GetMessages(int count)
        {
            var strings = StringFactory.GetStrings().AsList();
            var random = new Random();
            for (var i = 0; i < count; i++)
            {
                var index = random.Next(0, strings.Count - 1);
                yield return new Message
                {
                    Body = strings[index],
                    EnrichedBy = "DataProvider"
                };
            }
        }
    }
}
