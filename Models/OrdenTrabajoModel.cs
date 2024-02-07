namespace AutotechApi.Models
{
    public class OrdenTrabajoModel
    {
        public int Id_oder_trabajo { get; set; }
        public string description { get; set; }
        public byte status { get; set; }
        public int idUser { get; set;}
        public int idOrdenType { get; set; }
    }
}
