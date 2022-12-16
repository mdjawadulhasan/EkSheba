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
    public class PassportAppService
    {
        public static List<PassportAppDTO> Get()
        {

            var data = DataAccessFactory.PassportapplicationDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Passportapplication, PassportAppDTO>());
            var mapper = new Mapper(config);
            var p = mapper.Map<List<PassportAppDTO>>(data);
            return p;
        }

        public static PassportAppDTO GetbyFk(int id)
        {
            var data = DataAccessFactory.PassportapplicationDataAccess().GetbyFK(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Passportapplication, PassportAppDTO>());
            var mapper = new Mapper(config);
            var p = mapper.Map<PassportAppDTO>(data);
            return p;
        }


        public static bool Add(int id, int type)
        {

            Passportapplication pa = new Passportapplication();
            pa.PA_FK_NID = id;
            pa.ApplyDate = DateTime.Now;
            pa.Type = type;
            if (type == 1)
            {
                pa.DelDate = DateTime.Today.AddDays(7);
            }
            else if (type == 2)
            {
                pa.DelDate = DateTime.Today.AddDays(30);
            }
            else
            {
                pa.DelDate = DateTime.Today.AddDays(15);
            }
            var result = DataAccessFactory.PassportapplicationDataAccess().Add(pa);
            return result;
        }
    }
}
