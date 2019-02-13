using AdventureWorksApi.Configs;
using AdventureWorksApi.Models;
using Microsoft.Extensions.Options;
using RepoDb;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AdventureWorksApi.Repositories
{
    public class AddressRepository : BaseRepository<Address, SqlConnection>
    {
        public AddressRepository(IOptions<ApplicationConfig> appConfig)
            : base(appConfig.Value.ConnectionString)
        {
        }

        public IEnumerable<Address> GetByCustomerId(int customerId)
        {
            return ExecuteQuery(@"
                    SELECT A.*
                    FROM [SalesLT].[Address] A
                    INNER JOIN [SalesLT].[CustomerAddress] CA ON CA.AddressId = A.AddressId
                    WHERE (CA.CustomerId = @CustomerId);",
                new { CustomerId = customerId });
        }
    }
}
