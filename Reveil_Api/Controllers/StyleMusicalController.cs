using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reveil_Api.Models;
using System.Data.SqlClient;

namespace Reveil_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StyleMusicalController : ControllerBase
    {

        private readonly SqlConnection _connection;
        public StyleMusicalController(SqlConnection connection)
        {
            _connection = connection;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            string sql = "SELECT * FROM Style_musical";
            return Ok(_connection.Query<StyleMusical>(sql));
        }
    }
}
