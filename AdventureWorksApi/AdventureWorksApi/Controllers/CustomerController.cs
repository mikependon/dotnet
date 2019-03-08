using AdventureWorksApi.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController
    {
        private readonly CustomerManager m_customerManager;

        public CustomerController(CustomerManager customerManager)
        {
            m_customerManager = customerManager;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<WebModels.Customer>> GetAll()
        {
            return m_customerManager.GetAll()?.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<WebModels.Customer> Get(int id)
        {
            return m_customerManager.Get(id);
        }

        [HttpGet("getbatchafter/{lastCustomerId}/{numberOfRows}")]
        public ActionResult<IEnumerable<WebModels.Customer>> GetBatchAfter(int lastCustomerId, int numberOfRows)
        {
            return m_customerManager.GetBatchAfter(lastCustomerId, numberOfRows)?.ToList();
        }

        [HttpGet("send/{id}")]
        public ActionResult<WebModels.Customer> Send(int id)
        {
            return m_customerManager.Send(id);
        }
    }
}
