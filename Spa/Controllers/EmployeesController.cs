using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Spa.Utility;
using Spa.Models;
using System.Data.Entity;

namespace Spa.Controllers
{
    public class EmployeesController : ApiController
    {

		private ModelsController db = new ModelsController();

		[HttpPost]
		[ActionName("New")]
		public JsonResponse NewEmployee(Employee Employee) {

			JsonResponse json = new JsonResponse();
			if (ModelState.IsValid) {
				if (!(Employee == null)) {
					json.Data = db.Employees.Add(Employee);
					db.SaveChanges();
					return json;
				}
			}
			json.Message = "Unsuccessful. Please see error message";
			json.Result = "Failed";
			json.Error = db.Employees.Add(Employee);
			return json;
		}

		[HttpGet]
		[ActionName("Find")]
		public JsonResponse FindEmployee(int? Id) {
			JsonResponse json = new JsonResponse();
			if (Id == null) {
				json.Error = db.Employees.Find(Id);
				return json;
			}
			if (!(ModelState.IsValid)) {
				json.Error = db.Employees.Find(Id);
				json.Message = "Employee does not exist, try a different Id";
				return json;
			}
			json.Data = db.Employees.Find(Id);
			return json;
		}

		[HttpGet]
		[ActionName("Delete")]
		public JsonResponse Delete(int? Id) {
			JsonResponse json = new JsonResponse();
			if (!(Id == null)) {
				var Employee = db.Employees.Find(Id);
				if (ModelState.IsValid & Employee != null) {
					json.Message = $"Employee Id {Id} removed from records";
					db.Employees.Remove(Employee);
					db.SaveChanges();
					return json;

				}

			}
			json.Message = $"Id: {Id} does not exist.";
			return json;
		}

		[HttpPost]
		[ActionName("Modify")]
		public JsonResponse Modify(Employee Employee) {
			JsonResponse json = new JsonResponse();

			if (ModelState.IsValid) {
				db.Entry(Employee).State = EntityState.Modified;
				db.SaveChanges();
				json.Data = Employee;
				return json;
			}
			json.Data = Employee;
			json.Error = $"Employee ID {Employee.Id} does not exist";
			return json;

		}
		[HttpGet]
		[ActionName("List")]
		public JsonResponse List() {
			var list = db.Employees.ToList();
			JsonResponse json = new JsonResponse();
			json.Data = list;

			return json;
		}
	}
}
