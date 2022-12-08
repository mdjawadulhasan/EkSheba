using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    class UserDetailsRepo : Repo, IRepo<UsersDetail, int>,IAuth
    {
        public User Authenticate(string uname, string pass)
        {
            var obj = db.Users.FirstOrDefault(x => x.Uname.Equals(uname) && x.Password.Equals(pass));
            return obj;
        }
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

        public UsersDetail Get(string id)
        {
            throw new NotImplementedException();
        }

        
        public UsersDetail GetbyFK(int id)
        {
            return db.UsersDetails.FirstOrDefault(t => t.FK_Uid == id);
        }
    }
}
