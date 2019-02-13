using AdventureWorksApi.Extensions;
using AdventureWorksApi.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksApi.Managers
{
    public class ProductModelManager
    {
        private readonly ProductModelRepository m_productModelRepository;

        public ProductModelManager(ProductModelRepository productModelRepository)
        {
            m_productModelRepository = productModelRepository;
        }

        public IEnumerable<WebModels.ProductModel> GetAll()
        {
            return m_productModelRepository
                .Query()
                .Select(person => person.To<WebModels.ProductModel>());
        }

        public WebModels.ProductModel Get(int id)
        {
            return m_productModelRepository
                .Query(id)
                .Select(productModel => productModel.To<WebModels.ProductModel>())
                .FirstOrDefault();
        }
    }
}
