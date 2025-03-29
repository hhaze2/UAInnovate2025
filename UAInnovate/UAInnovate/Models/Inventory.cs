using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UAInnovate.Models
{
	public class Inventory
	{
        [Key]
        public int Id { get; set; }

        [Required]
        public string? ItemName { get; set; }

        [Required]
        public Office? OfficeLocation { get; set; }

        [Required]
        public int? CurrentAmount { get; set; }

        [Required]
        public int? AvgAmount { get; set; }

        [Required]
        public DateTime LastOrdered { get; set; }

  //      public Inventory()
		//{

		//}
	}
}

