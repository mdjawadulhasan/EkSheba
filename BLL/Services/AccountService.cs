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


        public static AccountDTO GetbyFk(int id)
        {
            var data = DataAccessFactory.AccountDataAccess().GetbyFK(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Account, AccountDTO>());
            var mapper = new Mapper(config);
            var acc = mapper.Map<AccountDTO>(data);
            return acc;
        }

        public static bool Add(int id)
        {

            Account acc = new Account();
            acc.Status = 0;
            acc.Balance = 0;
            acc.A_FK_Nid = id;
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

        public static bool Recharge(int id,int amount)
        {

            var acc = DataAccessFactory.AccountDataAccess().GetbyFK(id);
            if (acc.Status == 1)
            {
                int currnent_balance = (int)acc.Balance;
                currnent_balance += amount;
                acc.Balance = currnent_balance;
                var result = DataAccessFactory.AccountDataAccess().Update(acc);

                var rhistory = new RechargeHistory();
                rhistory.R_FK_Nid = id;
                rhistory.Amount = amount;
                rhistory.Date = DateTime.Now;
                

                result = DataAccessFactory.RechargeHistoryDataAccess().Add(rhistory);
                return result;
            }

            return false;
        }


        public static int CurentBalance(int id)
        {
            var acc = DataAccessFactory.AccountDataAccess().GetbyFK(id);
            if (acc.Status == 1)
            {
                return (int)acc.Balance;
            }
            else
            {
                return 0;
            }
        }

        public static void ChargeForPassport(int id, int type)
        {
            var acc = DataAccessFactory.AccountDataAccess().GetbyFK(id);
            int balance = (int)acc.Balance;

            if (type == 1)
            {
                balance = balance - 1000;
            }else if (type == 2)
            {
                balance = balance -7000;
            }else if (type == 3)
            {
                balance = balance - 5000;
            }

            acc.Balance = balance;
            DataAccessFactory.AccountDataAccess().Update(acc);

        }


        public static void ChargeAmount(int id, int amount)
        {
            var acc = DataAccessFactory.AccountDataAccess().GetbyFK(id);
            int balance = (int)acc.Balance;
            balance = balance - amount;
            acc.Balance = balance;
            DataAccessFactory.AccountDataAccess().Update(acc);

        }
    }
}
