using System;
using System.ComponentModel.DataAnnotations;

namespace GestionareProduse.Models
{
    public class Product
    {
        [Key]
        [MaxLength(6)]
        public string ProdId { get; set; }

        [MaxLength(75)]
        public string ProdName { get; set; }

        //[Range(5, 3000)]
        public float Price { get; set; }

        [MaxLength(100)]
        public string Color { get; set; }

        [MaxLength(6)]
        public string CatId { get; set; }

        [MaxLength(6)]
        public string BrandId { get; set; }

    }
}
