using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UAInnovate.Models
{
	public class MaintenanceRequests
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
        public string? Issue { get; set; }

        //this is the location of the issue
        [Required]
        public string? IssueLocation { get; set; }

        [Required]
        public string? Summary { get; set; }

        [Required]
        public PriorityTypes Priority { get; set; }

        [Required]
        public StatusTypes Status { get; set; }

  //      public MaintenanceRequests()
		//{
		//}
	}
}

