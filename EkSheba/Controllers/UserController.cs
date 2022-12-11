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
                var resp = UserDetailService.Add(u);
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

        [AdminFilter]
        [Route("api/user/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = UserDetailService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);

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

    }

}

    




