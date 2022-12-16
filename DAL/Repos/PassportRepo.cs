using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    class PassportRepo : Repo, IRepo<Passport, int>
    {
        public bool Add(Passport obj)
        {
            db.Passports.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var p = Get(id);
            db.Passports.Remove(p);
            return db.SaveChanges() > 0;
        }

        public List<Passport> Get()
        {
            throw new NotImplementedException();
        }

        public Passport Get(int id)
        {
            return db.Passports.Find(id);
        }

        public Passport Get(string id)
        {
            throw new NotImplementedException();
        }

        public Passport GetbyFK(int id)
        {
            return db.Passports.FirstOrDefault(t => t.P_FK_NID == id);
        }

        public bool Update(Passport obj)
        {
            var p = Get(obj.Id);
            db.Entry(p).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
