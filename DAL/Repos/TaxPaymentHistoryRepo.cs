using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    class TaxPaymentHistoryRepo : Repo, IRepo<TaxPaymentHistory, int>
    {
        public bool Add(TaxPaymentHistory obj)
        {
            db.TaxPaymentHistories.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var th = Get(id);
            db.TaxPaymentHistories.Remove(th);
            return db.SaveChanges() > 0;
        }

        public List<TaxPaymentHistory> Get()
        {
            return db.TaxPaymentHistories.ToList();
        }

        public TaxPaymentHistory Get(int id)
        {
            return db.TaxPaymentHistories.Find(id);
        }

        public TaxPaymentHistory Get(string id)
        {
            throw new NotImplementedException();
        }

        public TaxPaymentHistory Get(int id, string id2)
        {
            throw new NotImplementedException();
        }

        public TaxPaymentHistory GetbyFK(int id)
        {
            return db.TaxPaymentHistories.FirstOrDefault(t => t.IH_FK_NID == id);
        }

        public bool Update(TaxPaymentHistory obj)
        {
            var th = Get(obj.Id);
            db.Entry(th).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
