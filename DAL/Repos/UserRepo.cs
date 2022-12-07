using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    class UserRepo : Repo, IRepo<UsersDetail, int>
    {
        public bool Add(UsersDetail obj)
        {
            db.UsersDetails.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {

            var dbuser = Get(id);
            db.UsersDetails.Remove(dbuser);
            return db.SaveChanges() > 0;
        }

        public List<UsersDetail> Get()
        {
            return db.UsersDetails.ToList();
        }

        public UsersDetail Get(int id)
        {
            return db.UsersDetails.Find(id);
        }

        public bool Update(UsersDetail obj)
        {
            var dbuser = Get(obj.Nid);
            db.Entry(dbuser).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
