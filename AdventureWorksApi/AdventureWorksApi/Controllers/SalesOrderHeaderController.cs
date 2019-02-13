using AdventureWorksApi.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderHeaderController
    {
        private readonly SalesOrderHeaderManager m_salesOrderHeaderManager;

        public SalesOrderHeaderController(SalesOrderHeaderManager salesOrderHeaderManager)
        {
            m_salesOrderHeaderManager = salesOrderHeaderManager;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<WebModels.SalesOrderHeader>> GetAll()
        {
            return m_salesOrderHeaderManager.GetAll()?.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<WebModels.SalesOrderHeader> Get(int id)
        {
            return m_salesOrderHeaderManager.Get(id);
        }
    }
}
