using Microsoft.AspNetCore.Mvc;
using Neo4j.Driver;
using Neo4J_WebAPI.Models;
using Neo4J_WebAPI.Services;
using System.Text;


namespace Neo4J_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateTypeController : ControllerBase
    {
        private readonly IDriver _driver;

        public EstateTypeController(DatabaseService databaseService)
        {
            _driver = databaseService._driver;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEstateType(string name)
        {
            var statementText = new StringBuilder();
            statementText.Append("CREATE (type:EstateType {name: $name})");
            var statementParameters = new Dictionary<string, object>
        {
            {"name", name }
        };

            var session = this._driver.AsyncSession();
            var result = await session.WriteTransactionAsync(tx => tx.RunAsync(statementText.ToString(), statementParameters));
            return StatusCode(201, "Node has been created in the database");
        }


        [HttpGet]
        public async Task<string> GetEstateTpyeById(string id)
        {
            var statementText = new StringBuilder();
            statementText.Append("MATCH (type:EstateType) WHERE type.id = $id RETURN type");
            var statementParameters = new Dictionary<string, object>
        {
            {"id", id }
        };

            var session = this._driver.AsyncSession();
            var result = await session.ReadTransactionAsync(async x => x.RunAsync(statementText.ToString(), statementParameters));
            return null;
        }

        //[HttpGet]
        //public List<string> GetEstateTypes()
        //{
        //    using (var session = _driver.Session())
        //    {
        //        return session.ReadTransaction(tx =>
        //        {
        //            var result = tx.Run("MATCH (a:Person) RETURN a.name ORDER BY a.name");
        //            return result.Select(record => record[0].As<string>()).ToList();
        //        });
        //    }
        //}


    }
}