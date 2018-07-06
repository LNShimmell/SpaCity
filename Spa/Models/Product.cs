using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spa.Models {
	public class Product {

		public int Id { get; set; }
		public string Description { get; set; }
		[DataType("decimal(12,2)")]
		public decimal UnitCost { get; set; }
		public int? Stock { get; set; }
		public bool IsService { get; set; }
	}
}