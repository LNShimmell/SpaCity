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
    public class ProductsController : ApiController
    {
		private ModelsController db = new ModelsController();

		[HttpPost]
		[ActionName("New")]
		public JsonResponse NewProduct(Product Product) {

			JsonResponse json = new JsonResponse();
			if (ModelState.IsValid) {
				if (!(Product == null)) {
					json.Data = db.Products.Add(Product);
					db.SaveChanges();
					return json;
				}
			}
			json.Message = "Unsuccessful. Please see error message";
			json.Result = "Failed";
			json.Error = db.Products.Add(Product);
			return json;
		}

		[HttpGet]
		[ActionName("Find")]
		public JsonResponse FindProduct(int? Id) {
			JsonResponse json = new JsonResponse();
			if (Id == null) {
				json.Error = db.Products.Find(Id);
				return json;
			}
			if (!(ModelState.IsValid)) {
				json.Error = db.Products.Find(Id);
				json.Message = "Product does not exist, try a different Id";
				return json;
			}
			json.Data = db.Products.Find(Id);
			return json;
		}

		[HttpGet]
		[ActionName("Delete")]
		public JsonResponse Delete(int? Id) {
			JsonResponse json = new JsonResponse();
			if (!(Id == null)) {
				var Product = db.Products.Find(Id);
				if (ModelState.IsValid & Product != null) {
					json.Message = $"Product Id {Id} removed from records";
					db.Products.Remove(Product);
					db.SaveChanges();
					return json;

				}

			}
			json.Message = $"Id: {Id} does not exist.";
			return json;
		}

		[HttpPost]
		[ActionName("Modify")]
		public JsonResponse Modify(Product Product) {
			JsonResponse json = new JsonResponse();

			if (ModelState.IsValid) {
				db.Entry(Product).State = EntityState.Modified;
				db.SaveChanges();
				json.Data = Product;
				return json;
			}
			json.Data = Product;
			json.Error = $"Product ID {Product.Id} does not exist";
			return json;

		}
		[HttpGet]
		[ActionName("List")]
		public JsonResponse List() {
			var list = db.Products.ToList();
			JsonResponse json = new JsonResponse();
			json.Data = list;

			return json;
		}
	}
}
