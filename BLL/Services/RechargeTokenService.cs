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
                rc.Amount = 200;
                rc.Token = Guid.NewGuid().ToString();
                rc.Status = 0;
                result = DataAccessFactory.RechargeTokenDataAccess().Add(rc);

            }
            return result;

        }
    }
}
