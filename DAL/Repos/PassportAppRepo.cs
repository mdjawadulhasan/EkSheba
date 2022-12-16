using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    class PassportAppRepo : Repo, IRepo<Passportapplication, int>
    {
        public bool Add(Passportapplication obj)
        {

            db.Passportapplications.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var p = Get(id);
            db.Passportapplications.Remove(p);
            return db.SaveChanges() > 0;
        }

        public List<Passportapplication> Get()
        {
            return db.Passportapplications.ToList();
        }

        public Passportapplication Get(int id)
        {
            return db.Passportapplications.Find(id);
        }

        public Passportapplication Get(string id)
        {
            throw new NotImplementedException();
        }

        public Passportapplication Get(int id, string id2)
        {
            throw new NotImplementedException();
        }

        public Passportapplication GetbyFK(int id)
        {

            return db.Passportapplications.FirstOrDefault(t => t.PA_FK_NID == id);
        }

        public bool Update(Passportapplication obj)
        {
            var p = Get(obj.Id);
            db.Entry(p).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
