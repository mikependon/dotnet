using AdventureWorksApi.Configs;
using AdventureWorksApi.Models;
using Microsoft.Extensions.Options;
using RepoDb;
using System.Data.SqlClient;

namespace AdventureWorksApi.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory, SqlConnection>
    {
        public ProductCategoryRepository(IOptions<ApplicationConfig> appConfig)
            : base(appConfig.Value.DatabaseConnectionString)
        {
        }
    }
}
