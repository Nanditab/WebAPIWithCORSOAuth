
namespace ProductService.Models
{
    #region -- Using --
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    #endregion
    public class Product
    {
        public int ProductID { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}