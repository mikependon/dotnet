using DataProvider.EventServices;
using DataProvider.Models;
using DataProvider.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataProvider.Processor
{
    public class MessageDataProcessor
    {
        #region Properties

        public MessageRepository MessageRepository => new MessageRepository();

        public MessageEventService MessageEventService => new MessageEventService();

        #endregion

        #region Methods

        public async Task ProcessAsync(IEnumerable<Message> messages)
        {
            await MessageRepository.SaveAllAsync(messages);
            foreach (var message in messages)
            {
                await MessageEventService.MessageArriveAsync(message);
            }
        }

        #endregion
    }
}
