using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reveil_Api.Models;
using System.Data.SqlClient;

namespace Reveil_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReveilController : ControllerBase
    {
        private readonly SqlConnection _connection;
        public ReveilController(SqlConnection connection)
        {
            _connection = connection;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            string sql = "SELECT * FROM Reveil";
            return Ok(_connection.Query<Reveil>(sql));
        }

    }
}
