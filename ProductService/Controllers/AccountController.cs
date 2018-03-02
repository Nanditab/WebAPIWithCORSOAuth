using ProductService.Models;
using ProductService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProductService.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private IdentityRepository UserRepository { get; set; }

        public AccountController()
        {
            UserRepository = new IdentityRepository();
        }

        [HttpPut]
     //   [AllowAnonymous]
        public IHttpActionResult Register(User usermodel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (UserRepository.Register(usermodel))
            {
                return (IHttpActionResult) Request.CreateResponse(HttpStatusCode.OK);
            }
            else
                return(IHttpActionResult) Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, "Create failed");
        }

    }
}
