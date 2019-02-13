using AdventureWorksApi.Extensions;
using AdventureWorksApi.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksApi.Managers
{
    public class AddressManager
    {
        private readonly AddressRepository m_addressRepository;

        public AddressManager(AddressRepository addressRepository)
        {
            m_addressRepository = addressRepository;
        }

        public IEnumerable<WebModels.Address> GetAll()
        {
            return m_addressRepository
                .Query()
                .Select(person => person.To<WebModels.Address>());
        }

        public WebModels.Address Get(int id)
        {
            return m_addressRepository
                .Query(id)
                .Select(address => address.To<WebModels.Address>())
                .FirstOrDefault();
        }

        public IEnumerable<WebModels.Address> GetByCustomerId(int customerId)
        {
            return m_addressRepository.GetByCustomerId(customerId)
                .Select(address => address.To<WebModels.Address>());
        }
    }
}
