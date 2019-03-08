using AdventureWorksApi.Configs;
using AdventureWorksApi.Extensions;
using AdventureWorksApi.Repositories;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventureWorksApi.Managers
{
    public class CustomerManager
    {
        private readonly CustomerRepository m_customerRepository;
        private readonly ApplicationConfig m_config;

        public CustomerManager(IOptions<ApplicationConfig> config, CustomerRepository customerRepository)
        {
            m_config = config.Value;
            m_customerRepository = customerRepository;
        }

        public IEnumerable<WebModels.Customer> GetAll()
        {
            return m_customerRepository
                .Query()
                .Select(person => person.To<WebModels.Customer>());
        }

        public WebModels.Customer Get(int id)
        {
            return m_customerRepository
                .Query(id)
                .Select(customer => customer.To<WebModels.Customer>())
                .FirstOrDefault();
        }

        public IEnumerable<WebModels.Customer> GetBatchAfter(int lastCustomerId, int numberOfRows)
        {
            return m_customerRepository.GetBatchAfter(lastCustomerId, numberOfRows)
                .Select(customer => customer.To<WebModels.Customer>());
        }

        public WebModels.Customer Send(int id)
        {
            var customer = m_customerRepository
                .Query(id)
                .Select(item => item.To<WebModels.Customer>())
                .FirstOrDefault();
            if (customer != null)
            {
                var queueClient = new QueueClient(m_config.ServiceBusConnectionString, "Send");
                queueClient.SendAsync(new Message(Encoding.UTF8.GetBytes(ToJson(customer))));
                queueClient.CloseAsync();
            }
            return customer;
        }

        private string ToJson<T>(T obj) where T : class
        {
            var json = string.Empty;
            foreach (var property in typeof(T).GetProperties())
            {
                var value = property.GetValue(obj);
                json = string.Concat(json, ", ", Convert.ToString(value));
            }
            if (string.IsNullOrEmpty(json) == false)
            {
                json = json.Substring(0, json.Length - 2);
            }
            return json;
        }
    }
}
