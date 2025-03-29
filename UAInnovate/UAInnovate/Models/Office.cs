using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UAInnovate.Models
{
	public class Office
	{
        [Key]
        public int Id { get; set; }

        [Required]
        public string? OfficeName { get; set; }

        [Required]
        public string? Address { get; set; }

  //      public Office()
		//{

		//}
	}
}

