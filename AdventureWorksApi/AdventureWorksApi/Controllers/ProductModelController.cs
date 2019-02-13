using AdventureWorksApi.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductModelController
    {
        private readonly ProductModelManager m_productModelManager;

        public ProductModelController(ProductModelManager productModelManager)
        {
            m_productModelManager = productModelManager;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<WebModels.ProductModel>> GetAll()
        {
            return m_productModelManager.GetAll()?.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<WebModels.ProductModel> Get(int id)
        {
            return m_productModelManager.Get(id);
        }
    }
}
