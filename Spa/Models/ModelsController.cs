using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Spa.Models
{
	public class ModelsController : DbContext {
		public ModelsController() :base(){}

		public DbSet<Customer> Customers { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Appointment> Appointments { get; set; }
    }
}
