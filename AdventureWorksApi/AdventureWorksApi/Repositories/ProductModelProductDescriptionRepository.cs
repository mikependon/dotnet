using AdventureWorksApi.Configs;
using AdventureWorksApi.Models;
using Microsoft.Extensions.Options;
using RepoDb;
using System.Data.SqlClient;

namespace AdventureWorksApi.Repositories
{
    public class ProductModelProductDescriptionRepository : BaseRepository<ProductModelProductDescription, SqlConnection>
    {
        public ProductModelProductDescriptionRepository(IOptions<ApplicationConfig> appConfig)
            : base(appConfig.Value.ConnectionString)
        {
        }
    }
}
