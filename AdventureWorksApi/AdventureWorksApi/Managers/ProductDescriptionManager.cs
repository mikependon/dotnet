using AdventureWorksApi.Extensions;
using AdventureWorksApi.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksApi.Managers
{
    public class ProductDescriptionManager
    {
        private readonly ProductDescriptionRepository m_productDescriptionRepository;

        public ProductDescriptionManager(ProductDescriptionRepository productDescriptionRepository)
        {
            m_productDescriptionRepository = productDescriptionRepository;
        }

        public IEnumerable<WebModels.ProductDescription> GetAll()
        {
            return m_productDescriptionRepository
                .Query()
                .Select(person => person.To<WebModels.ProductDescription>());
        }

        public WebModels.ProductDescription Get(int id)
        {
            return m_productDescriptionRepository
                .Query(id)
                .Select(productDescription => productDescription.To<WebModels.ProductDescription>())
                .FirstOrDefault();
        }
    }
}
