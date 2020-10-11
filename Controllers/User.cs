using System;
using System.Data.Common;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    public class User : ControllerBase
    {
        public User(AppDb db)
        {
            Db = db;
        }

        // GET api/user/{cpf}
        [HttpGet("/api/user/{cpf}")]
        public async Task<IActionResult> GetLatest(string cpf)
        {
            await Db.Connection.OpenAsync();
            var query = new UserPostQuery(Db);
            var result = await query.LatestPostsAsync(cpf);
            return new OkObjectResult(result);
        }

        // GET ALL api/user/
        [HttpGet("/api/user/")]
        public async Task<IActionResult> GetAll()
        {
            await Db.Connection.OpenAsync();
            var query = new UserPostQuery(Db);
            var result = await query.AllPostsAsync();
            return new OkObjectResult(result);
        }

        // POST api/user/
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserModel body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertAsync();
            return new OkObjectResult(body);
        }

        // PUT api/user/{cpf}
        [HttpPut("{cpf}")]
        public async Task<IActionResult> PutOne(int cpf, [FromBody] UserModel body)
        {
            await Db.Connection.OpenAsync();
            var query = new UserPostQuery(Db);
            var result = await query.FirstPostAsync(cpf);
            if (result is null)
                return new NotFoundResult();
            result.CPF = body.CPF;
            result.Nome = body.Nome;
            result.Senha = body.Senha;
            result.Email = body.Email;
            await result.UpdateAsync();
            return new OkObjectResult(result);
        }

        // DELETE api/user/{cpf}
        [HttpDelete("{cpf}")]
        public async Task<IActionResult> DeleteOne(int cpf)
        {
            await Db.Connection.OpenAsync();
            var query = new UserPostQuery(Db);
            await query.DeleteAsync(cpf);
            return new OkResult();
        }

        // DELETE ALL api/user/
        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            await Db.Connection.OpenAsync();
            var query = new UserPostQuery(Db);
            await query.DeleteAllAsync();
            return new OkResult();
        }

        public AppDb Db { get; }
    }
} 