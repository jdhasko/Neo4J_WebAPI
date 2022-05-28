using Microsoft.Extensions.Options;
using Neo4j.Driver;
using Neo4J_WebAPI.Models;

namespace Neo4J_WebAPI.Services
{
    public class DatabaseService
    {

        public DatabaseService(IOptions<Neo4JConnectionSettings> databaseSettings)
        {
            var ConnectionString = databaseSettings.Value.ConnectionString;

            var username = databaseSettings.Value.Username;

            var passwrod = databaseSettings.Value.Password;

            _driver = GraphDatabase.Driver(ConnectionString, AuthTokens.Basic(username, passwrod));

        }
        public IDriver _driver { get; }

       // public GraphClient graphClient { get; }

    }
}
