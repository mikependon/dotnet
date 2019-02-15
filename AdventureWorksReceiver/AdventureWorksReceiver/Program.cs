using Microsoft.Azure.ServiceBus;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksReceiver
{
    class Program
    {
        private static string m_ConnectionString = "Endpoint=sb://mikependon-adventureworksapi.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=WO37aKBo+8BriVU0oWC5t7P9ixoHeyD26xJvw0hHRMk=";
        private static string m_queueName = "Send";
        private static IQueueClient m_queueClient;

        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            m_queueClient = new QueueClient(m_ConnectionString, m_queueName);
            Listen();
            Console.ReadKey();
            await m_queueClient.CloseAsync();
        }

        static void Listen()
        {
            var options = new MessageHandlerOptions(ExceptionHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };
            m_queueClient.RegisterMessageHandler(ProcessMessagesAsync, options);
        }

        private static async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            Console.WriteLine($"Received: {Encoding.UTF8.GetString(message.Body)}");
            await m_queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        private static Task ExceptionHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            Console.WriteLine($"Exception: {exceptionReceivedEventArgs.Exception.Message}");
            return Task.CompletedTask;
        }
    }
}
