namespace AutotechApi.Models
{
    public class RequerimientoModel
    {
        public int Id_requirement { get; set; }
        public string description { get; set; }
        public int idClient { get; set; }
        public DateTime date { get; set; }
    }
}
