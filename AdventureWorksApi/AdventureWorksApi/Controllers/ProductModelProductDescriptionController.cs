using AdventureWorksApi.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductModelProductDescriptionController
    {
        private readonly ProductModelProductDescriptionManager m_productModelProductDescriptionManager;

        public ProductModelProductDescriptionController(ProductModelProductDescriptionManager productModelProductDescriptionManager)
        {
            m_productModelProductDescriptionManager = productModelProductDescriptionManager;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<WebModels.ProductModelProductDescription>> GetAll()
        {
            return m_productModelProductDescriptionManager.GetAll()?.ToList();
        }
    }
}
