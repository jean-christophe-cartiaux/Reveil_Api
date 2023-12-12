namespace Reveil_Api.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string pseudo { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string pswd { get; set; }
        public string email { get; set; }
        public string categorie { get; set; }
    }
}
