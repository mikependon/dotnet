using AdventureWorksApi.Configs;
using AdventureWorksApi.Models;
using Microsoft.Extensions.Options;
using RepoDb;
using RepoDb.Extensions;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AdventureWorksApi.Repositories
{
    public class CustomerRepository : BaseRepository<Customer, SqlConnection>
    {
        public CustomerRepository(IOptions<ApplicationConfig> appConfig)
            : base(appConfig.Value.DatabaseConnectionString)
        {
        }

        public IEnumerable<Customer> GetBatchAfter(int lastCustomerId, int numberOfRows)
        {
            return Query(c => c.CustomerId < lastCustomerId,
                top: numberOfRows,
                orderBy: OrderField.Descending<Customer>(c => c.CustomerId).AsEnumerable());
        }
    }
}
