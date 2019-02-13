using AdventureWorksApi.Extensions;
using AdventureWorksApi.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksApi.Managers
{
    public class SalesOrderHeaderManager
    {
        private readonly SalesOrderHeaderRepository m_salesOrderHeaderRepository;

        public SalesOrderHeaderManager(SalesOrderHeaderRepository salesOrderHeaderRepository)
        {
            m_salesOrderHeaderRepository = salesOrderHeaderRepository;
        }

        public IEnumerable<WebModels.SalesOrderHeader> GetAll()
        {
            return m_salesOrderHeaderRepository
                .Query()
                .Select(person => person.To<WebModels.SalesOrderHeader>());
        }

        public WebModels.SalesOrderHeader Get(int id)
        {
            return m_salesOrderHeaderRepository
                .Query(id)
                .Select(salesOrderHeader => salesOrderHeader.To<WebModels.SalesOrderHeader>())
                .FirstOrDefault();
        }
    }
}
