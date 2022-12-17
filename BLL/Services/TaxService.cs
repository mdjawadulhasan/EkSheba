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
    public class TaxService
    {
        public static List<TaxDTO> Get()
        {
            var data = DataAccessFactory.TaxDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<IncomeTax, TaxDTO>());
            var mapper = new Mapper(config);
            var Taxes = mapper.Map<List<TaxDTO>>(data);
            return Taxes;
        }


        public static TaxDTO Get(int id)
        {
            var data = DataAccessFactory.TaxDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<IncomeTax, TaxDTO>());
            var mapper = new Mapper(config);
            var tax = mapper.Map<TaxDTO>(data);
            return tax;
        }


        public static TaxDTO GetbyFk(int id)
        {
            var data = DataAccessFactory.TaxDataAccess().GetbyFK(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<IncomeTax, TaxDTO>());
            var mapper = new Mapper(config);
            var tax = mapper.Map<TaxDTO>(data);
            return tax;
        }

        public static bool Add(int Grossamount, int id)
        {

            IncomeTax it = new IncomeTax();

            DateTime now = DateTime.Today;
            string currentyear = now.ToString("yyyy");
            
            it.IN_FK_NID = id;
            it.TaxAmount = Grossamount;
            it.Paid = 0;
            it.Balance = it.TaxAmount- it.Paid;
            it.Year = currentyear;


            var result = DataAccessFactory.TaxDataAccess().Add(it);
            return result;
        }

        public static bool Update(int Grossamount, int id)
        {

            var incometax = DataAccessFactory.TaxDataAccess().GetbyFK(id);
            incometax.TaxAmount = Grossamount;
            incometax.Balance = incometax.TaxAmount - incometax.Paid;
            var result = DataAccessFactory.TaxDataAccess().Update(incometax);
            return result;
        }
    }
}
