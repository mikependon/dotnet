using AdventureWorksApi.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController
    {
        private readonly ProductCategoryManager m_productCategoryManager;

        public ProductCategoryController(ProductCategoryManager productCategoryManager)
        {
            m_productCategoryManager = productCategoryManager;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<WebModels.ProductCategory>> GetAll()
        {
            return m_productCategoryManager.GetAll()?.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<WebModels.ProductCategory> Get(int id)
        {
            return m_productCategoryManager.Get(id);
        }
    }
}
