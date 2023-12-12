using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reveil_Api.Models;
using System.Data.SqlClient;

namespace Reveil_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SqlConnection _connection;
        public UsersController(SqlConnection connection) // création de la connection 
        {
            _connection = connection;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            string sql = "SELECT * FROM Users";
            return Ok(_connection.Query<Users>(sql));
        }
        [HttpPost]
        public async Task Create(Users Users)
        {
            string sql = "INSERT INTO Users (pseudo,nom, prenom,pswd,email, categorie) " +
                "VALUES (@pseudo,@nom, @prenom, @pswd,@email, @Categorie)";
            _connection.Execute(sql, Users);

        }
    }
}
