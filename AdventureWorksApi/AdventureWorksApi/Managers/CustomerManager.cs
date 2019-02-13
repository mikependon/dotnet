using AdventureWorksApi.Extensions;
using AdventureWorksApi.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksApi.Managers
{
    public class CustomerManager
    {
        private readonly CustomerRepository m_customerRepository;

        public CustomerManager(CustomerRepository customerRepository)
        {
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
    }
}
