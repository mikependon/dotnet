using AdventureWorksApi.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController
    {
        private readonly ProductManager m_productManager;

        public ProductController(ProductManager productManager)
        {
            m_productManager = productManager;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<WebModels.Product>> GetAll()
        {
            return m_productManager.GetAll()?.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<WebModels.Product> Get(int id)
        {
            return m_productManager.Get(id);
        }
    }
}
