using AdventureWorksApi.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAddressController
    {
        private readonly CustomerAddressManager m_customerAddressManager;

        public CustomerAddressController(CustomerAddressManager customerAddressManager)
        {
            m_customerAddressManager = customerAddressManager;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<WebModels.CustomerAddress>> GetAll()
        {
            return m_customerAddressManager.GetAll()?.ToList();
        }
    }
}
