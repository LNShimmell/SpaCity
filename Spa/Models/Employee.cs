using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spa.Models {
	public class Employee {
		public int Id { get; set; }
		[StringLength(30)]
		public string FirstName { get; set; }
		[StringLength(30)]
		public string LastName { get; set; }
		[StringLength(15)]
		public string Phone { get; set; }
		[DataType("decimal(12,2)")]
		public decimal Wage { get; set; } = 6;
		[DataType("decimal(12,2)")]
		public decimal TotalSalary { get; set; } = 0;
		public bool Barber { get; set; }

		public Employee() {

		}

		public Employee(string FirstName, string LastName, string Phone, decimal Rate, decimal Wage) {

		}
	}
}