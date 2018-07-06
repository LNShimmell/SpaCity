using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Spa.Models;
using Spa.Utility;

namespace Spa.Controllers
{
    public class CustomersController : ApiController
    {
		private ModelsController db = new ModelsController();


		[HttpPost]
		[ActionName("New")]
		public JsonResponse NewCustomer(Customer customer) {

			JsonResponse json = new JsonResponse();
			if (ModelState.IsValid) {
				if (!(customer == null)) {
					json.Data = db.Customers.Add(customer);
					db.SaveChanges();
					return json;
				}
			}
			json.Message = "Unsuccessful. Please see error message";
			json.Result = "Failed";
			json.Error = db.Customers.Add(customer);
			return json;
		}

		[HttpGet]
		[ActionName("Find")]
		public JsonResponse FindCustomer(int? Id) {
			JsonResponse json = new JsonResponse();
			if (Id == null) {
				json.Error = db.Customers.Find(Id);
				return json;
			}
			if (!(ModelState.IsValid)) {
				json.Error = db.Customers.Find(Id);
				json.Message = "Customer does not exist, try a different Id";
				return json;
			}
			json.Data = db.Customers.Find(Id);
			return json;
		}

		[HttpGet]
		[ActionName("Delete")]
		public JsonResponse Delete(int? Id) {
			JsonResponse json = new JsonResponse();
			if (!(Id == null)) {
				var customer = db.Customers.Find(Id);
				if (ModelState.IsValid & customer != null) {
					json.Message = $"Customer Id {Id} removed from records";
					db.Customers.Remove(customer);
					db.SaveChanges();
					return json;

				}

			}
			json.Message = $"Id: {Id} does not exist.";
			return json;
		}

		[HttpPost]
		[ActionName("Modify")]
		public JsonResponse Modify(Customer customer) {
			JsonResponse json = new JsonResponse();

			if (ModelState.IsValid) {
				db.Entry(customer).State = EntityState.Modified;
				db.SaveChanges();
				json.Data = customer;
				return json;
			}
			json.Data = customer;
			json.Error = $"Customer ID {customer.Id} does not exist";
			return json;

		}
		[HttpGet]
		[ActionName("List")]
		public JsonResponse List() {
			var list = db.Customers.ToList();
			JsonResponse json = new JsonResponse();
			json.Data = list;

			return json;
		}

	}
}
