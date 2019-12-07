using DataProvider.Models;
using RepoDb;
using System.Data.SqlClient;

namespace DataProvider.Repositories
{
    public class MessageRepository : BaseRepository<Message, SqlConnection>
    {
        public MessageRepository()
            : base("Server=tcp:mikependonsqlserver.database.windows.net,1433;Initial Catalog=Inventory;Persist Security Info=False;User ID=user;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        { }
    }
}
