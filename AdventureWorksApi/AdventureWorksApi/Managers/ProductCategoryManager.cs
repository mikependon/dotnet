using AdventureWorksApi.Extensions;
using AdventureWorksApi.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksApi.Managers
{
    public class ProductCategoryManager
    {
        private readonly ProductCategoryRepository m_productCategoryRepository;

        public ProductCategoryManager(ProductCategoryRepository productCategoryRepository)
        {
            m_productCategoryRepository = productCategoryRepository;
        }

        public IEnumerable<WebModels.ProductCategory> GetAll()
        {
            return m_productCategoryRepository
                .Query()
                .Select(person => person.To<WebModels.ProductCategory>());
        }

        public WebModels.ProductCategory Get(int id)
        {
            return m_productCategoryRepository
                .Query(id)
                .Select(productCategory => productCategory.To<WebModels.ProductCategory>())
                .FirstOrDefault();
        }
    }
}
