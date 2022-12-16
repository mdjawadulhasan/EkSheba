using BLL.DTOs;
using BLL.Services;
using EkSheba.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EkSheba.Controllers
{
    [EnableCors("*","*","*")]
    /*[AdminFilter]*/
    public class AdminController : ApiController
    {

        [Route("api/login/users")]
        [HttpGet]
        public HttpResponseMessage GetLogusers()
        {
            var data = LoginService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [Route("api/login/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage DeleteLogUser(int id)
        {
            var data = LoginService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }


        [Route("api/login/user/{id}")]
        [HttpGet]
        public HttpResponseMessage GetLogUser(int id)
        {
            var data = LoginService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [Route("api/users")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = UserDetailService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

       
        [Route("api/user/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage DeleteUser(int id)
        {
            var data = UserDetailService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }


        
        [Route("api/login/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage DeleteUserLog(int id)
        {
            var data = LoginService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }


        
        [Route("api/user/active/{id}")]
        [HttpPost]
        public HttpResponseMessage ActivateUser(int id)
        {
            var user = UserDetailService.Get(id);

            var resp = UserDetailService.ChangeStatus(user,"1");
            if (resp != false)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Activated", data = resp });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);

        }


        
        [Route("api/user/block/{id}")]
        [HttpPost]
        public HttpResponseMessage BlockUser(int id)
        {
            var user = UserDetailService.Get(id);
            var resp = UserDetailService.ChangeStatus(user, "2");
            if (resp != false)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Blocked", data = resp });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);

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
                var resp = AccountService.ChangeAccStatus(id, 1);
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
                    return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Blocked", data = resp });
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
        public HttpResponseMessage DeleteBankacc(int id)
        {
            var data = AccountService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }


        
        [Route("api/admin/BankAccount/genratetoken")]
        [HttpGet]
        public HttpResponseMessage GenrateRechargeToken()
        {
            var data = RechargeTokenService.GenrateRecharge();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
    }
}
