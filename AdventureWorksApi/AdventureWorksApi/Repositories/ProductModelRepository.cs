using AdventureWorksApi.Configs;
using AdventureWorksApi.Models;
using Microsoft.Extensions.Options;
using RepoDb;
using System.Data.SqlClient;

namespace AdventureWorksApi.Repositories
{
    public class ProductModelRepository : BaseRepository<ProductModel, SqlConnection>
    {
        public ProductModelRepository(IOptions<ApplicationConfig> appConfig)
            : base(appConfig.Value.DatabaseConnectionString)
        {
        }
    }
}
