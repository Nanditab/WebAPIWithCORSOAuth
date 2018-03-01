
namespace ProductService.Models
{
    #region -- Using --
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    #endregion
    public class User
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 100, ErrorMessage = "The {0} must be at least {2} characterslong.", MinimumLength =8)]
        public string Password { get; set; }

       [DataType(DataType.Password)]
       [Display(Name = "Confirm Password")]
       [Compare("Password",ErrorMessage = "Passwords doesnt match")]
        public string ConfirmPassword { get; set; }
    }
}