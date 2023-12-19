using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Reveil_Api.Models
{
    public class Users
    {
        
        public int Id { get; set; }
        [Required]
        public string pseudo { get; set; }
        [Required]
        public string nom { get; set; }
        [Required]
        public string prenom { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string pswd { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string categorie { get; set; }
    }
    public class Login
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string pswd { get; set; }
    }
}
