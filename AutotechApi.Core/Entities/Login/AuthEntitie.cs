namespace AutotechApi.Core.Entities.Login
{
    public class AuthEntitie
    {
        public int LoginType { get; set; }
        public int? IdIdentificationType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
