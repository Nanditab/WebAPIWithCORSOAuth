using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductService.Controllers
{   
    [Authorize]

    public class ProductWithPriceController : ApiController
    {
        #region -- Properties --
        static List<ProductWithPrice> Products { get; set; }
        #endregion

        #region -- Constructors --
        static ProductWithPriceController()
        {
            Products = new List<ProductWithPrice>
            {
                new ProductWithPrice{ Item = new Product{ ProductID=1, Title = "iPhone X", Description = "Features a new all-screen design. And the most powerfull and smartest chip evenr in an iPhone"}, Price = 999, Discount = 10.0M },
                new ProductWithPrice{ Item = new Product{ ProductID=2, Title = "Galaxy S8", Description = "Features Quad HD Infinity display, 12MP Dual Pixel Camera, Iris Scan & Face Recognition, Super AMOLED display, 64GB storage , 4GB RAM, Corning Gorilla Glass 5"}, Price = 910, Discount = 0.0M },
                new ProductWithPrice{ Item = new Product{ ProductID=3, Title = "OnePlus 5T", Description = "Bigger screen, borderless experience, Facial recognition to unlock your phone, High resolution"}, Price = 780, Discount = 20.0M },
                new ProductWithPrice{  Item = new Product{ ProductID=4, Title = "Google Pixel 2XL", Description = " features a smart camera, fast-charging battery and the Google Assistant built-in."},  Price = 599, Discount = 5 },

            };
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
            var product = Products.FirstOrDefault(p => p.Item.ProductID == id);
            if (product == null)
            {
                return BadRequest("Invalid ProductId");
            }
            return Ok(product);
        }
        
        #endregion
    }
}
