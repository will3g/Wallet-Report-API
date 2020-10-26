using System;
using System.Data.Common;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    public class Admin : ControllerBase
    {
        public Admin(AppDb db)
        {
            Db = db;
        }

        // DB MANAGER


        // GET ALL api/admin/db
        [HttpGet("db")]
        public async Task<IActionResult> GetAllDB()
        {
            await Db.Connection.OpenAsync();
            var query = new AdminPostQuery(Db);
            var result = await query.AllDBAsync();
            return new OkObjectResult(result);
        }

        // POST api/admin/db
        [HttpPost("db")]
        public async Task<IActionResult> PostDB([FromBody] AdminModel body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertDBAsync();
            return new OkObjectResult(body);
        }

        // DELETE api/admin/{NomeDB}
        [HttpDelete("{NomeDB}")]
        public async Task<IActionResult> DeleteOneDB(string NomeDB)
        {
            await Db.Connection.OpenAsync();
            var query = new AdminModel(Db);
            await query.DeleteDBAsync(NomeDB);
            return new OkResult();
        }

        // TABLE GERAL MANAGER

        //GET api/admin/{NomeDB}/table
        [HttpGet("{NomeDB}/table")]
        public async Task<IActionResult> GetAllTable(string NomeDB)
        {
            await Db.Connection.OpenAsync();
            var query = new AdminPostQuery(Db);
            var result = await query.AllTableAsync(NomeDB);
            return new OkObjectResult(result);
        }

        // PUT api/admin/{NomeDB}/{NomeTable}
        [HttpPut("{NomeDB}/{NomeTable}/{NewNomeTable}")]
        public async Task<IActionResult> PutOne(string NomeDB, string NomeTable, string NewNomeTable, [FromBody] AdminModel body)
        {
            await Db.Connection.OpenAsync();
            var query = new AdminPostQuery(Db);
            var result = await query.FirstPostTableAsync(NomeDB, NomeTable, NewNomeTable);
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // DELETE api/admin/{NomeDB}/{NomeTable}
        [HttpDelete("{NomeDB}/{NomeTable}")]
        public async Task<IActionResult> DeleteOneTable(string NomeDB, string NomeTable)
        {
            await Db.Connection.OpenAsync();
            var query = new AdminModel(Db);
            await query.DeleteTableAsync(NomeDB, NomeTable);
            return new OkResult();
        }

        // TABLE USER MANAGER

        //POST api/admin/user/db/table
        [HttpPost("user/db/table")]
        public async Task<IActionResult> PostTable([FromBody] AdminModel body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertTableAsync();
            return new OkObjectResult(body);
        }

        // TABLE COIN MANAGER

        //POST api/admin/coin/db/table
        [HttpPost("coin/db/table")]
        public async Task<IActionResult> PostCoin([FromBody] AdminModel body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertCoinAsync();
            return new OkObjectResult(body);
        }

        public AppDb Db { get; }
    }
}