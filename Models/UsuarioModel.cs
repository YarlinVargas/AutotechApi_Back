namespace AutotechApi.Models
{
    public class UsuarioModel
    {
        public int Id_user { get; set; }
        public string name { get; set; }
        public string birthday { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int idusserType { get; set; }
        public byte active { get; set; }
    }
}
