namespace AutotechApi.Models
{
    public class RecordatorioModel
    {
        public int Id_recordatorio { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int idClient { get; set; }
        public int idUser { get; set; }
        public DateTime date { get; set; }
        public byte active { get; set; }
    }
}
