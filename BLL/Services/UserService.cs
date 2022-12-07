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
    public class UserService
    {
        public static List<UsersDetailDTO> Get()
        {

            var data = DataAccessFactory.UserDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UsersDetail, UsersDetailDTO>());
            var mapper = new Mapper(config);
            var users = mapper.Map<List<UsersDetailDTO>>(data);
            return users;
        }


        public static UsersDetailDTO Get(int id)
        {
            var data = DataAccessFactory.UserDataAccess().Get(id);
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
            var result = DataAccessFactory.UserDataAccess().Add(data);
            return result;
        }

        public static bool Update(UsersDetailDTO dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UsersDetailDTO, UsersDetail>());
            var mapper = new Mapper(config);
            var data = mapper.Map<UsersDetail>(dto);
            var result = DataAccessFactory.UserDataAccess().Update(data);
            return result;

        }

        public static bool Delete(int id)
        {

            var result = DataAccessFactory.UserDataAccess().Delete(id);
            return result;

        }



    }
}
