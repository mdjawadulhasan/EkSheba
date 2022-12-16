using BLL.DTOs;
using BLL.Services;
using EkSheba.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace EkSheba.Controllers
{
    public class UserController : ApiController
    {
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

        [Route("api/user/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = UserDetailService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }


        [Route("api/users/add")]
        [HttpPost]
        public HttpResponseMessage Post(UsersDetailDTO u)
        {
            if (ModelState.IsValid)
            {
                var r = Request.Headers.Authorization;
                string token = r.ToString();
                var data = AuthService.GetCurrentUserLog(token);
                var resp = UserDetailService.Add(u, data.Id);

                if (resp != false)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Inserted", data = resp });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

        }


        [UserFilter]
        [Route("api/users/update")]
        [HttpPost]
        public HttpResponseMessage Update(UsersDetailDTO user)
        {
            if (ModelState.IsValid)
            {
                var resp = UserDetailService.Update(user);
                if (resp != false)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Inserted", data = resp });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

        }

        [UserFilter]
        [Route("api/users/bank/reqaccount")]
        [HttpPost]
        public HttpResponseMessage AddAccount()
        {

            var r = Request.Headers.Authorization;
            string token = r.ToString();
            var data = AuthService.GetCurrentUser(token);
            var resp = AccountService.Add(data.Nid);

            if (resp != false)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Inserted", data = resp });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }




        [UserFilter]
        [Route("api/users/bank/Recharge")]
        [HttpPost]
        public HttpResponseMessage Recharge(RechargeTokenDTO dto)
        {

            var r = Request.Headers.Authorization;
            string token = r.ToString();
            var data = AuthService.GetCurrentUser(token);

            if (dto != null)
            {
                int amount = RechargeTokenService.RechargeAmount(dto);
                if (amount > 0)
                {
                    var resp = AccountService.Recharge(data.Nid, amount);
                    if (resp != false)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Balance updated", data = resp });
                    }
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }



        [UserFilter]
        [Route("api/users/passport/apply/{type}")]
        [HttpGet]
        public HttpResponseMessage PassportApply(int type)
        {

            var r = Request.Headers.Authorization;
            string token = r.ToString();
            var user = AuthService.GetCurrentUser(token);


            var ExistsApp = PassportAppService.GetbyFk(user.Nid);
            int balance = AccountService.CurentBalance(user.Nid);

            if (ExistsApp != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Application Pending Already"});
            }
            else
            {
                if((type == 1 && balance < 10000) || (type == 2 && balance<7000) || (type == 3 && balance < 5000))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Insufficient Balance" });
                }
                else
                {
                    AccountService.ChargeForPassport(user.Nid,type);
                    bool res=PassportAppService.Add(user.Nid,type);
                    if (res)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Application submitted" });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError);
                    }
                }
                
            }


        }






    }

}






