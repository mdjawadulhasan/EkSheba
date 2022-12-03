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
        public static List<UserDTO> Get()
        {

            var data = DataAccessFactory.UserDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>());
            var mapper = new Mapper(config);
            var users = mapper.Map<List<UserDTO>>(data);
            return users;
        }


        public static UserDTO Get(int id)
        {
            var data = DataAccessFactory.UserDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>());
            var mapper = new Mapper(config);
            var user = mapper.Map<UserDTO>(data);
            return user;
        }

        public static bool Add(UserDTO dto)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>());
            var mapper = new Mapper(config);
            var data = mapper.Map<User>(dto);
            var result = DataAccessFactory.UserDataAccess().Add(data);
            return result;
        }

        public static bool Update(UserDTO dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>());
            var mapper = new Mapper(config);
            var data = mapper.Map<User>(dto);
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
