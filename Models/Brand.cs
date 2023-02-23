using System.ComponentModel.DataAnnotations;

namespace GestionareProduse.Models
{
	public class Brand
	{
		[Key]
		[MaxLength(6)]
		public string BrandId { get; set; }

		[MaxLength(75)]
		public string BrandName { get; set; }

		[MaxLength(3600)]
		public string Motto { get; set; }

	}
}
