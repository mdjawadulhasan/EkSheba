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
    public class TaxPaymentHistoryService
    {
        public static List<TaxPaymentHistoryDTO> Get()
        {

            var data = DataAccessFactory.TaxPaymentHistoryDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TaxPaymentHistory, TaxPaymentHistoryDTO>());
            var mapper = new Mapper(config);
            var taxes = mapper.Map<List<TaxPaymentHistoryDTO>>(data);
            return taxes;
        }

        public static TaxPaymentHistoryDTO Get(int id)
        {
            var data = DataAccessFactory.TaxPaymentHistoryDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TaxPaymentHistory, TaxPaymentHistoryDTO>());
            var mapper = new Mapper(config);
            var taxes = mapper.Map<TaxPaymentHistoryDTO>(data);
            return taxes;
        }


        public static bool Add(TaxPaymentHistoryDTO dto)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<TaxPaymentHistoryDTO, TaxPaymentHistory>());
            var mapper = new Mapper(config);
            var data = mapper.Map<TaxPaymentHistory>(dto);
            var result = DataAccessFactory.TaxPaymentHistoryDataAccess().Add(data);
            return result;
        }

    }
}
