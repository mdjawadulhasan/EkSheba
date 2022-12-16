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
    public class RechargeTokenService
    {
        public static bool GenrateRecharge()
        {
            bool result = false;
            for (int i = 0; i < 10; i++)
            {
                RechargeToken rc = new RechargeToken();
                rc.Amount = 5000;
                rc.Token = Guid.NewGuid().ToString();
                rc.Status = 0;
                result = DataAccessFactory.RechargeTokenDataAccess().Add(rc);

            }
            return result;
        }

        public static int RechargeAmount(RechargeTokenDTO dto)
        {
            var token = DataAccessFactory.RechargeTokenDataAccess().Get(dto.Token);
            if (token != null)
            {
                if (token.Status == 0)
                {
                    token.Status = 1;
                    DataAccessFactory.RechargeTokenDataAccess().Update(token);
                    return token.Amount;
                }
                return 0;
            }

            return 0;
        }


    }
}
