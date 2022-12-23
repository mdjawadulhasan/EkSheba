using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class JobApplyService
    {
        public static List<JobApplicationsDTO> Get()
        {

            var data = DataAccessFactory.JobApplyDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<JobApply, JobApplicationsDTO>());
            var mapper = new Mapper(config);
            var app = mapper.Map<List<JobApplicationsDTO>>(data);
            return app;
        }


        public static JobApplicationsDTO Get(int id)
        {
            var data = DataAccessFactory.JobApplyDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<JobApply, JobApplicationsDTO>());
            var mapper = new Mapper(config);
            var app= mapper.Map<JobApplicationsDTO>(data);
            return app;
        }



        public static JobApplicationsDTO IsExistsApplication(int id1,int id2)
        {
            string uid = id2.ToString();
            var data = DataAccessFactory.JobApplyDataAccess().Get(id1,uid);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<JobApply, JobApplicationsDTO>());
            var mapper = new Mapper(config);
            var app = mapper.Map<JobApplicationsDTO>(data);
            return app;
        }

        public static bool Add(int nid,int jid)
        {


            var userdata = UserDetailService.Get(nid);
            JobApply jap = new JobApply();
            jap.JAp_FK_NID = nid;
            jap.JAp_FK_JId = jid;
            jap.Date = DateTime.Now;
            jap.ApplicantName = userdata.Name;

            var resp = DataAccessFactory.JobApplyDataAccess().Add(jap);
            return resp;

        }


        public static bool Delete(int id)
        {
            var result = DataAccessFactory.JobApplyDataAccess().Delete(id);
            return result;
        }
    }
}
