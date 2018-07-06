using Spa.Models;
using Spa.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Spa.Controllers
{
    public class AppointmentsController : ApiController
    {
		private ModelsController db = new ModelsController();

		[HttpPost]
		[ActionName("New")]
		public JsonResponse NewAppointment(Appointment Appointment) {

			JsonResponse json = new JsonResponse();
			if (ModelState.IsValid) {
				if (!(Appointment == null)) {
					json.Data = db.Appointments.Add(Appointment);
					db.SaveChanges();
					return json;
				}
			}
			json.Message = "Unsuccessful. Please see error message";
			json.Result = "Failed";
			json.Error = db.Appointments.Add(Appointment);
			return json;
		}

		[HttpGet]
		[ActionName("Find")]
		public JsonResponse FindAppointment(int? Id) {
			JsonResponse json = new JsonResponse();
			if (Id == null) {
				json.Error = db.Appointments.Find(Id);
				return json;
			}
			if (!(ModelState.IsValid)) {
				json.Error = db.Appointments.Find(Id);
				json.Message = "Appointment does not exist, try a different Id";
				return json;
			}
			json.Data = db.Appointments.Find(Id);
			return json;
		}

		[HttpGet]
		[ActionName("Delete")]
		public JsonResponse Delete(int? Id) {
			JsonResponse json = new JsonResponse();
			if (!(Id == null)) {
				var Appointment = db.Appointments.Find(Id);
				if (ModelState.IsValid & Appointment != null) {
					json.Message = $"Appointment Id {Id} removed from records";
					db.Appointments.Remove(Appointment);
					db.SaveChanges();
					return json;

				}

			}
			json.Message = $"Id: {Id} does not exist.";
			return json;
		}

		[HttpPost]
		[ActionName("Modify")]
		public JsonResponse Modify(Appointment Appointment) {
			JsonResponse json = new JsonResponse();

			if (ModelState.IsValid) {
				db.Entry(Appointment).State = EntityState.Modified;
				db.SaveChanges();
				json.Data = Appointment;
				return json;
			}
			json.Data = Appointment;
			json.Error = $"Appointment ID {Appointment.Id} does not exist";
			return json;

		}
		[HttpGet]
		[ActionName("List")]
		public JsonResponse List() {
			var list = db.Appointments.ToList();
			JsonResponse json = new JsonResponse();
			json.Data = list;

			return json;
		}
	}
}
