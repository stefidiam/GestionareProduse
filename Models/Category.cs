using System.ComponentModel.DataAnnotations;

namespace GestionareProduse.Models
{
    public class Category
    {
        [Key]
        [MaxLength(6)]
        public string CatId { get; set; }

        [MaxLength(75)]
        public string CatName { get; set; }

        [MaxLength(100)]
        public string CatStatus { get; set; }
    }
}
