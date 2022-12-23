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
    public class JobCirculerService
    {
        public static List<JobCirculerDTO> Get()
        {

            var data = DataAccessFactory.JobCircularDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<JobCircular, JobCirculerDTO>());
            var mapper = new Mapper(config);
            var jc = mapper.Map<List<JobCirculerDTO>>(data);
            return jc;
        }


        public static JobCirculerDTO Get(int id)
        {
            var data = DataAccessFactory.JobCircularDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<JobCircular, JobCirculerDTO>());
            var mapper = new Mapper(config);
            var jc = mapper.Map<JobCirculerDTO>(data);
            return jc;
        }


        public static bool Add(JobCirculerDTO dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<JobCirculerDTO, JobCircular>());
            var mapper = new Mapper(config);
            var data = mapper.Map<JobCircular>(dto);
            var result = DataAccessFactory.JobCircularDataAccess().Add(data);
            return result;
        }


        public static bool Update(JobCirculerDTO dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<JobCirculerDTO, JobCircular>());
            var mapper = new Mapper(config);
            var data = mapper.Map<JobCircular>(dto);
            var result = DataAccessFactory.JobCircularDataAccess().Update(data);
            return result;

        }

        public static bool Delete(int id)
        {

            var result = DataAccessFactory.JobCircularDataAccess().Delete(id);
            return result;

        }

    }
}
