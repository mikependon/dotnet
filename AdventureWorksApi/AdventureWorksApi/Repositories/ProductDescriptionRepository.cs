using AdventureWorksApi.Configs;
using AdventureWorksApi.Models;
using Microsoft.Extensions.Options;
using RepoDb;
using System.Data.SqlClient;

namespace AdventureWorksApi.Repositories
{
    public class ProductDescriptionRepository : BaseRepository<ProductDescription, SqlConnection>
    {
        public ProductDescriptionRepository(IOptions<ApplicationConfig> appConfig)
            : base(appConfig.Value.DatabaseConnectionString)
        {
        }
    }
}
