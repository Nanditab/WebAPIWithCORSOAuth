namespace ProductService.Controllers
{
    using ProductService.Models;
    #region -- Using --
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Cors;
    #endregion
    [RoutePrefix("api/Products")]
    [EnableCors("*","*","GET,OPTIONS")]
    public class ProductsController : ApiController
    {
        #region -- Properties --
        static List<Product> Products { get; set; }
        #endregion

        #region -- Constructors --
        static ProductsController()
        {
            Products = new List<Product>
            {
                new Product{ ProductID=1, Title = "iPhone X", Description = "Features a new all-screen design. And the most powerfull and smartest chip evenr in an iPhone"},
                new Product{ ProductID=2, Title = "Galaxy S8", Description = "Features Quad HD Infinity display, 12MP Dual Pixel Camera, Iris Scan & Face Recognition, Super AMOLED display, 64GB storage , 4GB RAM, Corning Gorilla Glass 5"},
                new Product{ ProductID=3, Title = "OnePlus 5T", Description = "Bigger screen, borderless experience, Facial recognition to unlock your phone, High resolution"},
                new Product{ ProductID=4, Title = "Google Pixel 2XL", Description = " features a smart camera, fast-charging battery and the Google Assistant built-in."},

            };
        }

        public ProductsController()
        {
            //code to set allow origin in response object
            //if (string.Compare(HttpContext.Current.Request.HttpMethod, "OPTIONS", true) == 0)
            //{
            //    HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:54726/");
            //    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "PUT");
            //    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "*");
            //   // HttpContext.Current.Response.End();
            //}
        }
        #endregion

        #region -- Methods --
        public IHttpActionResult GetProducts()
        {
            return Ok(Products);
        }

        [Route("{id:int:min(1)}")]
        public IHttpActionResult GetProductById(int id)
        {
            var product = Products.FirstOrDefault(p => p.ProductID == id);
            if(product == null)
            {
                return BadRequest("Invalid ProductId");
            }
            return Ok(product);
        }

        [HttpPut]
        [EnableCors(origins: "http://localhost:54726", headers:"*",methods:"PUT")]
        public IHttpActionResult PutProduct(Product toUpdate)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("In valid model");
            }
            var productToUpdate = Products.FirstOrDefault(p => p.ProductID == toUpdate.ProductID);
            if(productToUpdate == null)
            {
                return BadRequest("Invalid prodict id");
            }
            productToUpdate.Title = toUpdate.Title;
            productToUpdate.Description = toUpdate.Description;
            return Ok();
        }
        #endregion
    }
}
