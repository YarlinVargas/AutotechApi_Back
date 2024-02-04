namespace AutotechApi.Models
{
    public class RepuestoModel
    {
        public int Id_parts { get; set; }
        public int num_serie { get; set; }
        public string name { get; set; }
        public string mark { get; set; }
        public decimal purchase_price { get; set; }
        public decimal sale_price { get; set; }
        public int idInventario { get; set; }
        public byte active { get; set; }    
    }
}
