

namespace ProductService.Models
{
    #region -- Using --
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    #endregion
    public class ProductWithPrice 
    {
        public Product Item { get; set; }
        public decimal Price { get; set; }

        public decimal Discount { get; set; }
    }
}