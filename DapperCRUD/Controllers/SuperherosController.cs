using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DapperCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperherosController : ControllerBase
    {
        private readonly IConfiguration _config;

        public SuperherosController(IConfiguration config)
        {
            _config = config;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllSuperHeroes()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));     // Dapper doesn't use DI in Program.cs
            IEnumerable<Superhero> heroes = await SelectAllSuperheroesAsync(connection);
            return Ok(heroes);
        }

        private async Task<IEnumerable<Superhero>> SelectAllSuperheroesAsync(SqlConnection connection)
        {
            return await connection.QueryAsync<Superhero>("select * from superheroes");     // Dapper
        }

        // Important ids in annotation and in argument match
        [HttpGet("{heroId}")]
        public async Task<IActionResult> GetAllSuperHeroes(int heroId)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var heroes = await connection.QueryFirstAsync<Superhero>("select * from superheroes where id = @Id", new { Id = heroId });      // An DTO can also be applied in this case
            return Ok(heroes);
        }


        [HttpPost]
        public async Task<IActionResult> CreateHero(Superhero hero)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("insert into superheroes (firstname, lastname, place) values (@FirstName, @LastName, @Place)", hero);     // when applying a command to the db use ExecuteAsync
            return Ok(await SelectAllSuperheroesAsync(connection));
        }


        [HttpPut]
        public async Task<IActionResult> UpdateHero(Superhero hero)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("update superheroes set firstname = @FirstName, lastname = @LastName, place = @Place where id = @Id", hero);
            return Ok(await SelectAllSuperheroesAsync(connection)); 
        }


        [HttpDelete("{heroId}")]
        public async Task<IActionResult> UpdateDelete(int heroId)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("delete from superheroes where id = @Id", new { Id = heroId });
            return Ok(await SelectAllSuperheroesAsync(connection));
        }



    }
}
