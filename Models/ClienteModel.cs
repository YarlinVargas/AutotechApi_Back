namespace AutotechApi.Models
{
    public class ClienteModel
    {
        public int Id_cliente { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string telephoneNumber { get; set;}
        public string email { get; set; }
        public byte active { get; set; }
    }
}
