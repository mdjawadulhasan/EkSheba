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
                    var cfg = new MapperConfiguration(c => {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    var data = mapper.Map<TokenDTO>(rttk);
                    return data;
                }
            }
            return null;
        }
        public static bool IsTokenValid(string token,int utype)
        {
            var tk = DataAccessFactory.TokenDataAccess().Get(token);

            DateTime dt1 = (DateTime)tk.ExpirationTime;
            DateTime crnt = DateTime.Now;

            var username = tk.Username;


            if (tk != null && tk.ExpirationTime == null)
            {
                return true;
            }
            return false;


        }
    }
}

