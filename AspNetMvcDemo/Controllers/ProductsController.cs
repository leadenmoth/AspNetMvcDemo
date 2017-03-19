using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AspNetMvcDemo.Models;

namespace AspNetMvcDemo.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductDbContext db = new ProductDbContext();

        /// <summary>
        /// Get list of products from server
        /// </summary>
        /// <param name="q">Search string for Name, Category and Description fields</param>
        /// <returns></returns>
        public IQueryable<Product> GetProducts(string q="")
        {
            var products = from p in db.Products select p;
            //search in textfields with ?q=<string>
            if (!String.IsNullOrEmpty(q))
            {
                products = products.Where(p => p.Name.Contains(q)
                                       || p.Category.Contains(q)
                                       || p.Description.Contains(q));
            }
            return products;
        }

        /// <summary>
        /// Look up a single product by Product Number
        /// </summary>
        /// <param name="id">Product Number, integer</param>
        /// <returns></returns>
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ID == id) > 0;
        }
    }
}