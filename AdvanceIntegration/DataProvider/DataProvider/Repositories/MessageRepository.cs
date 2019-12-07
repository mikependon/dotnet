using DataProvider.Models;
using RepoDb;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataProvider.Repositories
{
    public class MessageRepository
    {
        #region Properties

        public string ConnectionString => "Server=tcp:mikependonsqlserver.database.windows.net,1433;Initial Catalog=Inventory;Persist Security Info=False;User ID=user;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        #endregion

        #region Methods

        public async Task<int> SaveAllAsync(IEnumerable<Message> messages)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return await connection.InsertAllAsync<Message>(messages);
            }
        }

        #endregion
    }
}
