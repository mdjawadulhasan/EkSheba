using DAL.EF;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<UsersDetail, int> UserDetailDataAccess()
        {
            return new UserDetailsRepo();
        }
        public static IAuth AuthDataAccess()
        {
            return new UserDetailsRepo();
        }

        public static ITokenRepo<Token, string, Token> TokenDataAccess()
        {
            return new TokenRepo();
        }

        public static IRepo<User, int> LoginDataAccess()
        {
            return new LoginRepo();
        }

        public static IRepo<Account, int> AccountDataAccess()
        {
            return new AccountRepo();
        }


        public static IRepo<RechargeToken, int> RechargeTokenDataAccess()
        {
            return new RechargeTokenRepo();
        }

        public static IRepo<RechargeHistory, int> RechargeHistoryDataAccess()
        {
            return new RechargeHistoryRepo();
        }

        public static IRepo<Passportapplication, int> PassportapplicationDataAccess()
        {
            return new PassportAppRepo();
        }

        public static IRepo<Passport, int> PassportDataAccess()
        {
            return new PassportRepo();
        }

        public static IRepo<FiscalYIncome, int> FiscalYIncomeDataAccess()
        {
            return new FiscalYIncomeRepo();
        }

        public static IRepo<IncomeTax, int> TaxDataAccess()
        {
            return new TaxRepo();
        }

        public static IRepo<TaxPaymentHistory, int> TaxPaymentHistoryDataAccess()
        {
            return new TaxPaymentHistoryRepo();
        }


        public static IRepo<UserAcademicInfo, int> UserAcademicInfoDataAccess()
        {
            return new UserAcademicInfoRepo();
        }

        public static IRepo<JobCircular, int> JobCircularDataAccess()
        {
            return new JobCirculerRepo();
        }


        public static IRepo<JobApply, int> JobApplyDataAccess()
        {
            return new JobApplicationsRepo();
        }

    }
}