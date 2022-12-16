using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    class FiscalYIncomeRepo : Repo, IRepo<FiscalYIncome, int>
    {
        public bool Add(FiscalYIncome obj)
        {
            db.FiscalYIncomes.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var Fincome = Get(id);
            db.FiscalYIncomes.Remove(Fincome);
            return db.SaveChanges() > 0;
        }

        public List<FiscalYIncome> Get()
        {
            return db.FiscalYIncomes.ToList();
        }

        public FiscalYIncome Get(int id)
        {
            return db.FiscalYIncomes.Find(id);
        }

        public FiscalYIncome Get(string id)
        {
            throw new NotImplementedException();
        }

        public FiscalYIncome Get(int id, string year)
        {
            return db.FiscalYIncomes.FirstOrDefault(t => t.Fis_FK_NID == id && t.Year==year);
        }

        public FiscalYIncome GetbyFK(int id)
        {
            return db.FiscalYIncomes.FirstOrDefault(t => t.Fis_FK_NID == id);
        }

        public bool Update(FiscalYIncome obj)
        {
            var fincome = Get(obj.id);
            db.Entry(fincome).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
