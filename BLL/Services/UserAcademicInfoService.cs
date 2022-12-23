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
    public class UserAcademicInfoService
    {
        public static List<UserAcademicInfoDTO> Get()
        {

            var data = DataAccessFactory.UserAcademicInfoDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserAcademicInfo, UserAcademicInfoDTO>());
            var mapper = new Mapper(config);
            var rs = mapper.Map<List<UserAcademicInfoDTO>>(data);
            return rs;
        }

        public static UserAcademicInfoDTO Get(int id)
        {
            var data = DataAccessFactory.UserAcademicInfoDataAccess().GetbyFK(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserAcademicInfo, UserAcademicInfoDTO>());
            var mapper = new Mapper(config);
            var res = mapper.Map<UserAcademicInfoDTO>(data);
            return res;
        }


        public static bool Add(UserAcademicInfoDTO dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserAcademicInfoDTO, UserAcademicInfo>());
            var mapper = new Mapper(config);
            var data = mapper.Map<UserAcademicInfo>(dto);
            var result = DataAccessFactory.UserAcademicInfoDataAccess().Add(data);
            return result;
        }


        public static bool Update(UserAcademicInfoDTO dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserAcademicInfoDTO, UserAcademicInfo>());
            var mapper = new Mapper(config);
            var data = mapper.Map<UserAcademicInfo>(dto);
            var result = DataAccessFactory.UserAcademicInfoDataAccess().Update(data);
            return result;

        }

        public static bool Delete(int id)
        {

            var result = DataAccessFactory.UserAcademicInfoDataAccess().Delete(id);
            return result;

        }
    }
}
