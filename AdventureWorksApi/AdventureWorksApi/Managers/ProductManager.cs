using AdventureWorksApi.Extensions;
using AdventureWorksApi.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksApi.Managers
{
    public class ProductManager
    {
        private readonly ProductRepository m_productRepository;

        public ProductManager(ProductRepository productRepository)
        {
            m_productRepository = productRepository;
        }

        public IEnumerable<WebModels.Product> GetAll()
        {
            return m_productRepository
                .Query()
                .Select(person => person.To<WebModels.Product>());
        }

        public WebModels.Product Get(int id)
        {
            return m_productRepository
                .Query(id)
                .Select(product => product.To<WebModels.Product>())
                .FirstOrDefault();
        }
    }
}
