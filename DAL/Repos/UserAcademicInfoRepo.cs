using DAL.Interfaces;
using System;
using DAL.EF;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    class UserAcademicInfoRepo : Repo, IRepo<UserAcademicInfo, int>
    {
        public bool Add(UserAcademicInfo obj)
        {
            db.UserAcademicInfoes.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ui = Get(id);
            db.UserAcademicInfoes.Remove(ui);
            return db.SaveChanges() > 0;
        }

        public List<UserAcademicInfo> Get()
        {
            return db.UserAcademicInfoes.ToList();
        }

        public UserAcademicInfo Get(int id)
        {
            return db.UserAcademicInfoes.Find(id);
        }

        public UserAcademicInfo Get(string id)
        {
            throw new NotImplementedException();
        }

        public UserAcademicInfo Get(int id, string id2)
        {
            throw new NotImplementedException();
        }

        public UserAcademicInfo GetbyFK(int id)
        {
            return db.UserAcademicInfoes.FirstOrDefault(t => t.R_FK_NID == id);
        }

        public bool Update(UserAcademicInfo obj)
        {
            var rs = Get(obj.RId);
            db.Entry(rs).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
