using AdventureWorksApi.Extensions;
using AdventureWorksApi.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksApi.Managers
{
    public class SalesOrderDetailManager
    {
        private readonly SalesOrderDetailRepository m_salesOrderDetailRepository;

        public SalesOrderDetailManager(SalesOrderDetailRepository salesOrderDetailRepository)
        {
            m_salesOrderDetailRepository = salesOrderDetailRepository;
        }

        public IEnumerable<WebModels.SalesOrderDetail> GetAll()
        {
            return m_salesOrderDetailRepository
                .Query()
                .Select(person => person.To<WebModels.SalesOrderDetail>());
        }

        public WebModels.SalesOrderDetail Get(int id)
        {
            return m_salesOrderDetailRepository
                .Query(id)
                .Select(salesOrderDetail => salesOrderDetail.To<WebModels.SalesOrderDetail>())
                .FirstOrDefault();
        }
    }
}
