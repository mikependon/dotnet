using AdventureWorksApi.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderDetailController
    {
        private readonly SalesOrderDetailManager m_salesOrderDetailManager;

        public SalesOrderDetailController(SalesOrderDetailManager salesOrderDetailManager)
        {
            m_salesOrderDetailManager = salesOrderDetailManager;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<WebModels.SalesOrderDetail>> GetAll()
        {
            return m_salesOrderDetailManager.GetAll()?.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<WebModels.SalesOrderDetail> Get(int id)
        {
            return m_salesOrderDetailManager.Get(id);
        }
    }
}
