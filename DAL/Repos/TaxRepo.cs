using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    class TaxRepo : Repo, IRepo<IncomeTax, int>
    {
        public bool Add(IncomeTax obj)
        {
            db.IncomeTaxes.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var incomeTax = Get(id);
            db.IncomeTaxes.Remove(incomeTax);
            return db.SaveChanges() > 0;
        }

        public List<IncomeTax> Get()
        {
            return db.IncomeTaxes.ToList();
        }

        public IncomeTax Get(int id)
        {
            return db.IncomeTaxes.Find(id);
        }

        public IncomeTax Get(string id)
        {
            throw new NotImplementedException();
        }

        public IncomeTax Get(int id, string id2)
        {
            throw new NotImplementedException();
        }

        public IncomeTax GetbyFK(int id)
        {
            return db.IncomeTaxes.FirstOrDefault(t => t.IN_FK_NID == id);
        }

        public bool Update(IncomeTax obj)
        {
            var Incometax = Get(obj.Id);
            db.Entry(Incometax).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
