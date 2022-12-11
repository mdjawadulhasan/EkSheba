using BLL.DTOs;
using BLL.Services;
using EkSheba.Auth;
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

        [AdminFilter]
        [Route("api/users")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = UserDetailService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        

        [AdminFilter]
        [Route("api/login/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            var data = LoginService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [UserFilter]
        [Route("api/login/update")]
        [HttpPost]
        public HttpResponseMessage Update(LoginDTO user)
        {
            if (ModelState.IsValid)
            {
                var resp = LoginService.Update(user);
                if (resp != false)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Updated", data = resp });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

        }

        [AdminFilter]
        [Route("api/admin/BankAccount/accounts")]
        [HttpGet]
        public HttpResponseMessage GetAccounts()
        {
            var data = AccountService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }




        [AdminFilter]
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

        [AdminFilter]
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

        [AdminFilter]
        [Route("api/admin/BankAccount/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage DeleteBankacc(int id)
        {
            var data = AccountService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }


        [AdminFilter]
        [Route("api/admin/BankAccount/genratetoken")]
        [HttpGet]
        public HttpResponseMessage GenrateRechargeToken()
        {
            var data = RechargeTokenService.GenrateRecharge();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
    }
}
