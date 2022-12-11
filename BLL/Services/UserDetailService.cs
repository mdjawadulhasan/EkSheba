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
    public class UserDetailService
    {
        public static List<UsersDetailDTO> Get()
        {

            var data = DataAccessFactory.UserDetailDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UsersDetail, UsersDetailDTO>());
            var mapper = new Mapper(config);
            var users = mapper.Map<List<UsersDetailDTO>>(data);
            return users;
        }


        public static UsersDetailDTO Get(int id)
        {
            var data = DataAccessFactory.UserDetailDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UsersDetail, UsersDetailDTO>());
            var mapper = new Mapper(config);
            var user = mapper.Map<UsersDetailDTO>(data);
            return user;
        }

        public static bool Add(UsersDetailDTO dto)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<UsersDetailDTO, UsersDetail>());
            var mapper = new Mapper(config);
            var data = mapper.Map<UsersDetail>(dto);
            var result = DataAccessFactory.UserDetailDataAccess().Add(data);
            return result;
        }

        public static bool Update(UsersDetailDTO dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UsersDetailDTO, UsersDetail>());
            var mapper = new Mapper(config);
            var data = mapper.Map<UsersDetail>(dto);
            var result = DataAccessFactory.UserDetailDataAccess().Update(data);
            return result;

        }

        public static bool Delete(int id)
        {

            var result = DataAccessFactory.UserDetailDataAccess().Delete(id);
            return result;

        }


        public static bool ChangeStatus(UsersDetailDTO dto,string status)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UsersDetailDTO, UsersDetail>());
            var mapper = new Mapper(config);
            var data = mapper.Map<UsersDetail>(dto);
            data.Status = status;
            var result = DataAccessFactory.UserDetailDataAccess().Update(data);
            return result;

        }


    }
}
