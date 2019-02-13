using AdventureWorksApi.Configs;
using AdventureWorksApi.Models;
using Microsoft.Extensions.Options;
using RepoDb;
using System.Data.SqlClient;

namespace AdventureWorksApi.Repositories
{
    public class ProductRepository : BaseRepository<Product, SqlConnection>
    {
        public ProductRepository(IOptions<ApplicationConfig> appConfig)
            : base(appConfig.Value.ConnectionString)
        {
        }
    }
}
