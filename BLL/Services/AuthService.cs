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
    public class AuthService
    {
        public static TokenDTO Authenticate(string uname, string pass)
        {
            var user = DataAccessFactory.AuthDataAccess().Authenticate(uname, pass);
            if (user != null)
            {
                var tk = new Token();
                tk.Username = user.Uname;
                tk.CreationTime = DateTime.Now;

                DateTime dt1 = DateTime.Now;
                DateTime dt2 = dt1.AddMinutes(15);
                tk.ExpirationTime = dt2;
                tk.Tkey = Guid.NewGuid().ToString();
                var rttk = DataAccessFactory.TokenDataAccess().Add(tk);
                if (rttk != null)
                {
                    var cfg = new MapperConfiguration(c =>
                    {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    var data = mapper.Map<TokenDTO>(rttk);
                    return data;
                }
            }
            return null;
        }
        public static bool IsTokenValid(string token, int utype)
        {
            var tk = DataAccessFactory.TokenDataAccess().Get(token);
            var CurrentUser = GetCurrentUser(token);
            string status = "2";
            if (CurrentUser != null)
            {
                status = CurrentUser.Status;
            }

            if (tk != null)
            {
                DateTime dt1 = (DateTime)tk.ExpirationTime;
                DateTime crnt = DateTime.Now;

                var userlog = DataAccessFactory.LoginDataAccess().Get(tk.Username);
                if (utype == 2)
                {
                    if (DateTime.Compare(crnt, dt1) < 0 && utype == userlog.Type && !status.Equals(2))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (DateTime.Compare(crnt, dt1) < 0 && utype == userlog.Type)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            return false;
        }


        public static UsersDetailDTO GetCurrentUser(string token)
        {

            var tk = DataAccessFactory.TokenDataAccess().Get(token);
            var loginuser = DataAccessFactory.LoginDataAccess().Get(tk.Username);
            var data = DataAccessFactory.UserDetailDataAccess().GetbyFK(loginuser.Id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UsersDetail, UsersDetailDTO>());
            var mapper = new Mapper(config);
            var user = mapper.Map<UsersDetailDTO>(data);
            return user;
        }

        public static LoginDTO GetCurrentUserLog(string token)
        {

            var tk = DataAccessFactory.TokenDataAccess().Get(token);
            var loginuser = DataAccessFactory.LoginDataAccess().Get(tk.Username);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, LoginDTO>());
            var mapper = new Mapper(config);
            var user = mapper.Map<LoginDTO>(loginuser);
            return user;
        }


    }
}

