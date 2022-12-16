using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    class RechargeHistoryRepo : Repo, IRepo<RechargeHistory, int>
    {
        public bool Add(RechargeHistory obj)
        {
            db.RechargeHistories.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var rc = Get(id);
            db.RechargeHistories.Remove(rc);
            return db.SaveChanges() > 0;
        }

        public List<RechargeHistory> Get()
        {
            return db.RechargeHistories.ToList();
        }

        public RechargeHistory Get(int id)
        {
            return db.RechargeHistories.Find(id);
        }

        public RechargeHistory Get(string id)
        {
            throw new NotImplementedException();
        }

        public RechargeHistory Get(int id, string id2)
        {
            throw new NotImplementedException();
        }

        public RechargeHistory GetbyFK(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(RechargeHistory obj)
        {
            var rc = Get(obj.Id);
            db.Entry(rc).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
