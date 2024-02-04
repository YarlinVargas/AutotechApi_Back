namespace AutotechApi.Models
{
    public class SoporteModel
    {
        public int Id_support { get; set; }
        public string description { get; set; }
        public int idClient { get; set; }
        public int iduser { get; set; }
        public DateTime date { get; set; }
        public byte active { get; set; }
    }
}
