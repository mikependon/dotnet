using AdventureWorksApi.Extensions;
using AdventureWorksApi.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksApi.Managers
{
    public class CustomerAddressManager
    {
        private readonly CustomerAddressRepository m_customerAddressRepository;

        public CustomerAddressManager(CustomerAddressRepository customerAddressRepository)
        {
            m_customerAddressRepository = customerAddressRepository;
        }

        public IEnumerable<WebModels.CustomerAddress> GetAll()
        {
            return m_customerAddressRepository
                .Query()
                .Select(person => person.To<WebModels.CustomerAddress>());
        }

        public WebModels.CustomerAddress Get(int id)
        {
            return m_customerAddressRepository
                .Query(id)
                .Select(customerAddress => customerAddress.To<WebModels.CustomerAddress>())
                .FirstOrDefault();
        }
    }
}
