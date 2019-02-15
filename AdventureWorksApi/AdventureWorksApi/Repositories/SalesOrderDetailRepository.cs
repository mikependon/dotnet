using AdventureWorksApi.Configs;
using AdventureWorksApi.Models;
using Microsoft.Extensions.Options;
using RepoDb;
using System.Data.SqlClient;

namespace AdventureWorksApi.Repositories
{
    public class SalesOrderDetailRepository : BaseRepository<SalesOrderDetail, SqlConnection>
    {
        public SalesOrderDetailRepository(IOptions<ApplicationConfig> appConfig)
            : base(appConfig.Value.DatabaseConnectionString)
        {
        }
    }
}
