using AdventureWorksApi.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController
    {
        private readonly AddressManager m_addressManager;

        public AddressController(AddressManager addressManager)
        {
            m_addressManager = addressManager;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<WebModels.Address>> GetAll()
        {
            return m_addressManager.GetAll()?.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<WebModels.Address> Get(int id)
        {
            return m_addressManager.Get(id);
        }

        [HttpGet("getbycustomerid/{customerId}")]
        public IEnumerable<WebModels.Address> GetByCustomerId(int customerId)
        {
            return m_addressManager.GetByCustomerId(customerId)?.ToList();
        }
    }
}
