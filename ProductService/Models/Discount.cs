
#region -- Using --
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion
namespace ProductService.Models
{
    public class Discount
    {
        public int ProductId { get; set; }

        public decimal DiscountAmount { get; set; }

        public string DiscountType { get; set; }
    }
}