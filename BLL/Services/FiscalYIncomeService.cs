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
    public class FiscalYIncomeService
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


        public static bool Update(FiscalYIncomeDTO dto)
        {
            DateTime now = DateTime.Today;
            string currentyear = now.ToString("yyyy");
            if (currentyear.Equals(dto.Year))
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<FiscalYIncomeDTO, FiscalYIncome>());
                var mapper = new Mapper(config);
                var data = mapper.Map<FiscalYIncome>(dto);
                var result = DataAccessFactory.FiscalYIncomeDataAccess().Update(data);
                return true;

            }
            else
            {
                return false;
            }

        }

        public static int CalculatedTax(FiscalYIncomeDTO dto)
        {

            int maxHouseRent = (int)(dto.BasicSalary / 2);
            int maxMedicalAllowance = (int)(dto.BasicSalary * 10) / 100;
            int maxConveyance = 30000;


            int TaxableHouseRent = 0;
            int TaxableMeicalAl = 0;
            int TaxableConveyance = 0;

            if (dto.HouseRent > maxHouseRent)
            {
                TaxableHouseRent = (int)(dto.HouseRent - TaxableHouseRent);
            }
            if (dto.MedicalAllowancw > maxMedicalAllowance)
            {
                TaxableMeicalAl = (int)(dto.MedicalAllowancw - maxMedicalAllowance);
            }
            if (dto.Conveyance > maxConveyance)
            {
                TaxableConveyance = (int)(dto.Conveyance - maxConveyance);
            }

            int TotalTaxableAmount = (int)(dto.BasicSalary + TaxableHouseRent + TaxableMeicalAl + TaxableConveyance + dto.Incentive + dto.FestivalBonus);


            int GrossTaxable = 0;
            if (TotalTaxableAmount >= 300000 && TotalTaxableAmount < 400000)
            {
                GrossTaxable = (TotalTaxableAmount * 5) / 100;
            }
            else if (TotalTaxableAmount >= 400000 && TotalTaxableAmount < 700000)
            {
                GrossTaxable = (TotalTaxableAmount * 10) / 100;
            }
            else if (TotalTaxableAmount >= 700000 && TotalTaxableAmount < 1100000)
            {
                GrossTaxable = (TotalTaxableAmount * 15) / 100;
            }
            else if (TotalTaxableAmount >= 1100000 && TotalTaxableAmount < 1600000)
            {
                GrossTaxable = (TotalTaxableAmount * 20) / 100;
            }
            else if (TotalTaxableAmount >= 1600000)
            {
                GrossTaxable = (TotalTaxableAmount * 25) / 100;
            }


            return GrossTaxable;
        }
    }
}
