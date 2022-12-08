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
    public class AccountService
    {

        public static List<AccountDTO> Get()
        {

            var data = DataAccessFactory.AccountDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Account, AccountDTO>());
            var mapper = new Mapper(config);
            var accounts = mapper.Map<List<AccountDTO>>(data);
            return accounts;
        }

        public static AccountDTO Get(int id)
        {
            var data = DataAccessFactory.AccountDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Account, AccountDTO>());
            var mapper = new Mapper(config);
            var acc = mapper.Map<AccountDTO>(data);
            return acc;
        }

        public static bool Add(AccountDTO dto)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<AccountDTO, Account>());
            var mapper = new Mapper(config);
            var acc = mapper.Map<Account>(dto);
            acc.Status = 0;
            acc.Balance = 0;
            var result = DataAccessFactory.AccountDataAccess().Add(acc);
            return result;
        }

        public static bool ChangeAccStatus(int id,int status)
        {

            var acc = DataAccessFactory.AccountDataAccess().Get(id);
            acc.Status = status;
            var result = DataAccessFactory.AccountDataAccess().Update(acc);
            return result;

        }


        public static bool Delete(int id)
        {
            var result = DataAccessFactory.AccountDataAccess().Delete(id);
            return result;
        }
    }
}
