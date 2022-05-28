using Microsoft.AspNetCore.Mvc;
using Neo4j.Driver;
using Neo4J_WebAPI.Models;
using Neo4J_WebAPI.Services;
using System.Text;

namespace Neo4J_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Neo4jController : ControllerBase
    {
        private readonly IDriver _driver;

        public Neo4jController(DatabaseService databaseService)
        {
            _driver = databaseService._driver;
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateNode2(string name) {
        //    var query = _client.Cypher
        //        .Create("(villager:VILLAGER, {name:{name}})")
        //        .WithParam("name", name)
        //        .ExecuteWithoutResultsAsync();
        //    return Ok(query); 
        //}

        [HttpPost]
        public async Task<IActionResult> CreateNode(string name)
        {
            var statementText = new StringBuilder();
            statementText.Append("CREATE (person:Person {name: $name})");
            var statementParameters = new Dictionary<string, object>
        {
            {"name", name }
        };

            var session = this._driver.AsyncSession();
            var result = await session.WriteTransactionAsync(tx => tx.RunAsync(statementText.ToString(), statementParameters));
            return StatusCode(201, "Node has been created in the database");
        }
    }
}