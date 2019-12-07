using DataProvider.Models;
using DataProvider.Repositories;
using RepoDb;
using System.Collections.Generic;

namespace DataProvider.Processor
{
    public class MessageDataProcessor
    {
        public int Process(IEnumerable<Message> messages)
        {
            using (var repository = new MessageRepository())
            {
                return repository.BulkInsert(messages);
            }
        }
    }
}
