using AdventureWorksApi.Configs;
using AdventureWorksApi.Models;
using Microsoft.Extensions.Options;
using RepoDb;
using System.Data.SqlClient;

namespace AdventureWorksApi.Repositories
{
    public class SalesOrderHeaderRepository : BaseRepository<SalesOrderDetail, SqlConnection>
    {
        public SalesOrderHeaderRepository(IOptions<ApplicationConfig> appConfig)
            : base(appConfig.Value.DatabaseConnectionString)
        {
        }
    }
}
