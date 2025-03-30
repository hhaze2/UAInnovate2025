using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UAInnovate.Models
{
	public class OfficeSupplyRequests
	{
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public string? OfficeLocation { get; set; }

        [Required]
        public OfficeSupplyTypes Type { get; set; }

        [Required]
        public string? ItemName { get; set; }

        [Required]
        public CurrStockTypes CurrStock { get; set; }

        [Required]
        public string? AdditionalInfo { get; set; }

        [Required]
        public PriorityTypes Priority { get; set; }

        [Required]
        public StatusTypes Status { get; set; }

  //      public OfficeSupplyRequests()
		//{
		//}
	}
}

