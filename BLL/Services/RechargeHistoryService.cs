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
    public class RechargeHistoryService
    {
        public static List<RechargeHistoryDTO> Get()
        {

            var data = DataAccessFactory.RechargeHistoryDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RechargeHistory, RechargeHistoryDTO>());
            var mapper = new Mapper(config);
            var rechargeHistories = mapper.Map<List<RechargeHistoryDTO>>(data);
            return rechargeHistories;
        }


    }
}
