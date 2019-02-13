using AdventureWorksApi.Configs;
using AdventureWorksApi.Models;
using Microsoft.Extensions.Options;
using RepoDb;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AdventureWorksApi.Repositories
{
    public class CustomerAddressRepository : BaseRepository<CustomerAddress, SqlConnection>
    {
        public CustomerAddressRepository(IOptions<ApplicationConfig> appConfig)
            : base(appConfig.Value.ConnectionString)
        {
        }
    }
}
