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
        public HttpResponseMessage Post(UsersDetailDTO group)
        {
            if (ModelState.IsValid)
            {
                var resp = UserDetailService.Add(group);
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


        [Route("api/user/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = UserDetailService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }


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


        [Route("api/users/bank/reqaccount")]
        [HttpPost]
        public HttpResponseMessage AddAccount(AccountDTO acc)
        {
            if (ModelState.IsValid)
            {
                var resp = AccountService.Add(acc);
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


    }
}
