using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UAInnovate.Models
{
	public class UserModels
	{

        public int Id { get; set; }

        public string ForeignId { get; set; }

        public DateOnly DayAdded { get; set; }

        public string Username { get; set; }

        //these are the user's roles
        public List<string> permissons { get; set; }

        public Office? WorkLocation { get; set; }



  //      public UserModels()
		//{
		//}
	}
}

