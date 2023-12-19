using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reveil_Api.Models;
using System.ComponentModel.DataAnnotations;
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
        [HttpPost("register")]
        public async Task<IActionResult> Create(Users Users)
        {
            string sql = "select email from users where email = @email";
            string email = (string)_connection.ExecuteScalar(sql, new { email = Users.email }); //! verifier que l'email est bien présente ! 
            if (email is null) //! si l'email envoyer existe tu sort sinon tu entre dans la condition 
            {
                string sql2 = "INSERT INTO Users (pseudo,nom, prenom,pswd,email, categorie) " + //! insertion des données 
                "VALUES (@pseudo,@nom, @prenom, @pswd,@email, @categorie)";
                Users? u = _connection.QuerySingleOrDefault<Users>(sql2, Users); //!  on push le user 
                return Ok();
            }
            return BadRequest("email utilisé ! "); //! pas de chance ton email existe déjas on ta pirater bolosse !!!



        }
        [HttpPost("login")]
        public async Task<IActionResult> login(Login Users)
        {
            string sql = "select * from users where email= @email"; //! requete Sql 
            Login? u = _connection.QuerySingleOrDefault<Login>(sql, new { email = Users.email }); //! on cherche l'email corespondent 
            if (u is not null) //! si email non valide tu rentre pas dans les condition sinon tu rentre dans les condition 
            {
                if (Users.pswd == u.pswd) //! si sa match youpie je vous déclare Email et Email  pour les meilleur comme pour le pire !! 
                {
                    return Ok(u); //! return le U 
                }
                return BadRequest("mauvais mdp");
            }
            return BadRequest("Aucun user avec ce mail");


        }
    }
}
