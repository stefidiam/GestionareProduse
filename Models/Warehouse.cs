using System.ComponentModel.DataAnnotations;

namespace GestionareProduse.Models
{
    public class Warehouse
    {
        [Key]
        [MaxLength(6)]
        public string DepId { get; set; }

        [MaxLength(75)]
        public string Quantity { get; set; }

        public string ProdId { get; set; }
    }
}
