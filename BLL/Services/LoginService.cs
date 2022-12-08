﻿using AutoMapper;
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
    public class LoginService
    {
        public static LoginDTO Get(int id)
        {
            var data = DataAccessFactory.LoginDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, LoginDTO>());
            var mapper = new Mapper(config);
            var user = mapper.Map<LoginDTO>(data);
            return user;
        }

        public static bool Add(LoginDTO dto)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<LoginDTO, User>());
            var mapper = new Mapper(config);
            var data = mapper.Map<User>(dto);
            var result = DataAccessFactory.LoginDataAccess().Add(data);
            return result;
        }

        public static bool Update(LoginDTO dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LoginDTO, User>());
            var mapper = new Mapper(config);
            var data = mapper.Map<User>(dto);
            var result = DataAccessFactory.LoginDataAccess().Update(data);
            return result;

        }
        public static bool Delete(int id)
        {

            var result = DataAccessFactory.LoginDataAccess().Delete(id);
            return result;

        }

    }
}