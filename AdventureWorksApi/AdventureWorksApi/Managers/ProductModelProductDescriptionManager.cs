using AdventureWorksApi.Extensions;
using AdventureWorksApi.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksApi.Managers
{
    public class ProductModelProductDescriptionManager
    {
        private readonly ProductModelProductDescriptionRepository m_productModelProductDescriptionRepository;

        public ProductModelProductDescriptionManager(ProductModelProductDescriptionRepository productModelProductDescriptionRepository)
        {
            m_productModelProductDescriptionRepository = productModelProductDescriptionRepository;
        }

        public IEnumerable<WebModels.ProductModelProductDescription> GetAll()
        {
            return m_productModelProductDescriptionRepository
                .Query()
                .Select(person => person.To<WebModels.ProductModelProductDescription>());
        }
    }
}
