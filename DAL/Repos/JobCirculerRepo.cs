using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    class JobCirculerRepo : Repo, IRepo<JobCircular, int>
    {
        public bool Add(JobCircular obj)
        {
            db.JobCirculars.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var jc = Get(id);
            db.JobCirculars.Remove(jc);
            return db.SaveChanges() > 0;
        }

        public List<JobCircular> Get()
        {
            return db.JobCirculars.ToList();
        }

        public JobCircular Get(int id)
        {
            return db.JobCirculars.Find(id);
        }

        public JobCircular Get(string id)
        {
            throw new NotImplementedException();
        }

        public JobCircular Get(int id, string id2)
        {
            throw new NotImplementedException();
        }

        public JobCircular GetbyFK(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(JobCircular obj)
        {
            var acc = Get(obj.JCid);
            db.Entry(acc).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
