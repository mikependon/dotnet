using AdventureWorksApi.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDescriptionController
    {
        private readonly ProductDescriptionManager m_productDescriptionManager;

        public ProductDescriptionController(ProductDescriptionManager productDescriptionManager)
        {
            m_productDescriptionManager = productDescriptionManager;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<WebModels.ProductDescription>> GetAll()
        {
            return m_productDescriptionManager.GetAll()?.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<WebModels.ProductDescription> Get(int id)
        {
            return m_productDescriptionManager.Get(id);
        }
    }
}
