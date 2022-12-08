using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EkSheba.Controllers
{
    public class AdminController : ApiController
    {

        [Route("api/users")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = UserDetailService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }


        [Route("api/admin/BankAccount/accounts")]
        [HttpGet]
        public HttpResponseMessage GetAccounts()
        {
            var data = AccountService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }





        [Route("api/admin/BankAccount/AcceptAccount/{id}")]
        [HttpGet]
        public HttpResponseMessage AcceptAcc(int id)
        {
            if (ModelState.IsValid)
            {
                var resp = AccountService.ChangeAccStatus(id,1);
                if (resp != false)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Accepted", data = resp });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

        }


        [Route("api/admin/BankAccount/BlockAccount/{id}")]
        [HttpGet]
        public HttpResponseMessage BlockAcc(int id)
        {
            if (ModelState.IsValid)
            {
                var resp = AccountService.ChangeAccStatus(id, 2);
                if (resp != false)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Accepted", data = resp });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

        }

        [Route("api/admin/BankAccount/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = AccountService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
    }
}
