using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spa.Models {
	public class Customer {
		public int Id { get; set; }
		[StringLength(30)]
		public string FirstName { get; set; }
		[StringLength(30)]
		public string LastName { get; set; }
		[StringLength(15)]
		public string Phone { get; set; }

	}
}