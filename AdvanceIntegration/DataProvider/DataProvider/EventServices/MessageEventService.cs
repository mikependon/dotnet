using DataProvider.Models;
using Microsoft.Azure.EventHubs;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider.EventServices
{
    public class MessageEventService
    {
        #region Privates

        private EventHubClient m_messageArriveClient = null;

        #endregion

        #region Properties

        public string ConnectionString => "EntityPath=MessageArrive;Endpoint=sb://mikependoneventhub.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=b3nELDsDIU9JPLYjX+1GzD7ht3Bkf3WATjRONL54dcg=";

        #endregion

        #region Methods

        public async Task MessageArriveAsync(Message message)
        {
            var client = GetMessageArriveClient();
            var eventData = new EventData(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message)));
            await client.SendAsync(eventData);
        }

        #endregion

        #region Helper

        private EventHubClient GetMessageArriveClient()
        {
            if (m_messageArriveClient == null || m_messageArriveClient?.IsClosed == true)
            {
                m_messageArriveClient = GetEventHubClient("MessageArrive");
            }
            return m_messageArriveClient;
        }

        private EventHubClient GetEventHubClient(string entityPath)
        {
            var connectionString = $"EntityPath={entityPath};{ConnectionString}";
            return EventHubClient.CreateFromConnectionString(ConnectionString);
        }

        #endregion
    }
}
