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
    class FiscalYIncomeService
    {
        public static FiscalYIncomeDTO Get(int id)
        {
            var data = DataAccessFactory.FiscalYIncomeDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FiscalYIncome, FiscalYIncomeDTO>());
            var mapper = new Mapper(config);
            var income = mapper.Map<FiscalYIncomeDTO>(data);
            return income;
        }


        public static bool Add(FiscalYIncomeDTO dto, int id)
        {
            DateTime now = DateTime.Today;
            string currentyear = now.ToString("yyyy");
            var exfisincome = DataAccessFactory.FiscalYIncomeDataAccess().Get(id, currentyear);
            if (exfisincome != null)
            {
                return false;
            }

            else
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<FiscalYIncomeDTO, FiscalYIncome>());
                var mapper = new Mapper(config);
                var data = mapper.Map<FiscalYIncome>(dto);
                data.Fis_FK_NID = id;
                data.Year = currentyear;
                var result = DataAccessFactory.FiscalYIncomeDataAccess().Add(data);
                return result;
            }
        }
    }
}
