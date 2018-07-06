using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spa.Models {
	public class Appointment {
		public int Id { get; set; }
		public int EmployeeId { get; set; }
		public virtual Employee Employee { get; set; }
		public int CustomerId { get; set; }
		public virtual Customer Customer { get; set; }
		[StringLength(200)]
		public string Description { get; set; }
		public DateTime DateTime { get; set; }
	}
}