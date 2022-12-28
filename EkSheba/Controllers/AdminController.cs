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
    [EnableCors("*", "*", "*")]
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


        [Route("api/user/active/{id}")]
        [HttpPost]
        public HttpResponseMessage ActivateUser(int id)
        {
            var user = UserDetailService.Get(id);

            var resp = UserDetailService.ChangeStatus(user, "1");
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

       /* [AccountsAdmin]*/
        [Route("api/admin/BankAccount/accounts")]
        [HttpGet]
        public HttpResponseMessage GetAccounts()
        {
            var data = AccountService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }




        /*[AccountsAdmin]*/
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

        /*[AccountsAdmin]*/
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

       /* [AccountsAdmin]*/
        [Route("api/admin/BankAccount/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage DeleteBankacc(int id)
        {
            var data = AccountService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }


        /*[AccountsAdmin]*/
        [Route("api/admin/BankAccount/genratetoken")]
        [HttpGet]
        public HttpResponseMessage GenrateRechargeToken()
        {
            var data = RechargeTokenService.GenrateRecharge();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

       /* [PassportAdmin]*/
        [Route("api/admin/passport/applications")]
        [HttpGet]
        public HttpResponseMessage GetPassportapplications()
        {
            var data = PassportAppService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        /*[PassportAdmin]*/
        [Route("api/admin/passports")]
        [HttpGet]
        public HttpResponseMessage GetPassports()
        {
            var data = PassportService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        /*[PassportAdmin]*/
        [Route("api/admin/passport/Accept/{id}")]
        [HttpGet]
        public HttpResponseMessage AcceptPassport(int id)
        {
            bool resp = PassportService.AcceptRequest(id);
            if (resp)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Accepted", data = resp });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            

        }

       /* [PassportAdmin]*/
        [Route("api/admin/passport/Block/{id}")]
        [HttpGet]
        public HttpResponseMessage BlockPassport(int id)
        {
            bool resp = PassportService.ChangeStatus(id,2);
            if (resp)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Blocked", data = resp });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

        }

        /* [PassportAdmin]*/
        [Route("api/admin/passport/Active/{id}")]
        [HttpGet]
        public HttpResponseMessage ActivePassport(int id)
        {
            bool resp = PassportService.ChangeStatus(id,1);
            if (resp)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Actived", data = resp });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

        }

        //[EducationAdmin]
        [Route("api/user/academicinfo/add")]
        [HttpPost]
        public HttpResponseMessage Post(UserAcademicInfoDTO dto)
        {

            var resp = UserAcademicInfoService.Add(dto);
            if (resp != false)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Registered", data = resp });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);

        }


       // [EducationAdmin]
        [Route("api/user/academicinfo/update")]
        [HttpPost]
        public HttpResponseMessage Updateacademic(UserAcademicInfoDTO dto)
        {

            var resp = UserAcademicInfoService.Update(dto);
            if (resp != false)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Registered", data = resp });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);

        }


       // [EducationAdmin]
        [Route("api/user/academicinfo/{id}")]
        [HttpGet]
        public HttpResponseMessage Viewacademic(int id)
        {

            var data = UserAcademicInfoService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }



        //-----------------------
        //[EducationAdmin]
        [Route("api/job/add")]
        [HttpPost]
        public HttpResponseMessage JobPost(JobCirculerDTO dto)
        {

            var resp = JobCirculerService.Add(dto);
            if (resp != false)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Registered", data = resp });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);

        }


        // [EducationAdmin]
        [Route("api/job/update")]
        [HttpPost]
        public HttpResponseMessage UpdateJob(JobCirculerDTO dto)
        {

            var resp = JobCirculerService.Update(dto);
            if (resp != false)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Registered", data = resp });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);

        }


        // [EducationAdmin]
        [Route("api/job")]
        [HttpGet]
        public HttpResponseMessage ViewJObs()
        {

            var data = JobCirculerService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }


        [Route("api/job/{id}")]
        [HttpGet]
        public HttpResponseMessage ViewJOb(int id)
        {

            var data = JobCirculerService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }


        [Route("api/job/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Deletejob(int id)
        {
            var data = JobCirculerService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        //------------

        [Route("api/jobapplications")]
        [HttpGet]
        public HttpResponseMessage ViewJobApplications()
        {

            var data = JobApplyService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }


        [Route("api/jobapplication/{id}")]
        [HttpGet]
        public HttpResponseMessage VewJobApplication(int id)
        {

            var data = JobApplyService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [Route("api/jobapplication/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage DeletejobApplications(int id)
        {
            var data = JobApplyService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
    }
}
