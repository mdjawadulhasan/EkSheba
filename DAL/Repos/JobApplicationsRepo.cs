using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    class JobApplicationsRepo : Repo, IRepo<JobApply, int>
    {
        public bool Add(JobApply obj)
        {
            db.JobApplies.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var jap = Get(id);
            db.JobApplies.Remove(jap);
            return db.SaveChanges() > 0;
        }

        public List<JobApply> Get()
        {
            return db.JobApplies.ToList();
        }

        public JobApply Get(int id)
        {
            return db.JobApplies.Find(id);
        }

        public JobApply Get(string id)
        {
            throw new NotImplementedException();
        }

        public JobApply Get(int id, string id2)
        {
            int Userid = Int32.Parse(id2);
            return db.JobApplies.FirstOrDefault(t => t.JAp_FK_JId == id && t.JAp_FK_NID==Userid);
        }

        public JobApply GetbyFK(int id)
        {
            return db.JobApplies.FirstOrDefault(t => t.JAp_FK_NID == id);
        }

        public bool Update(JobApply obj)
        {
            var acc = Get(obj.JApid);
            db.Entry(acc).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
