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
    public class PassportService
    {

        public static bool AcceptRequest(int id)
        {

            var req = DataAccessFactory.PassportapplicationDataAccess().Get(id);
            int type = (int)req.Type;
            int userid = (int)req.PA_FK_NID;

            if (type == 3)
            {
                var edata = DataAccessFactory.PassportDataAccess().GetbyFK(userid);
                edata.ValidTill = DateTime.Today.AddYears(5);
                edata.Status = 1;
                bool b = DataAccessFactory.PassportDataAccess().Update(edata);
                return b;
            }
            else
            {
                Passport p = new Passport();
                p.P_FK_NID = userid;
                p.IssueDate = DateTime.Now;
                p.ValidTill = DateTime.Today.AddYears(5);
                p.Status = 1;
                bool b = DataAccessFactory.PassportDataAccess().Add(p);

                return b;
            }

            return false;
        }



    }
}
