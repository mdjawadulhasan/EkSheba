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

namespace EkSheba.Controllers
{
    public class AuthController : ApiController
    {
        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Login(LoginDTO login)
        {
            if (login == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Username password not supplied");
            }
            if (ModelState.IsValid)
            {
                var token = AuthService.Authenticate(login.Uname, login.Password);
                if (token != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, token);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "Username password invalid");
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/login/add")]
        [HttpPost]
        public HttpResponseMessage Post(LoginDTO user)
        {
            if (ModelState.IsValid)
            {
                var resp = LoginService.Add(user);
                if (resp != false)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Registered", data = resp });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

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

    }
}

