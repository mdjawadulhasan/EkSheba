﻿using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    class LoginRepo : Repo, IRepo<User, int>
    {
        public bool Add(User obj)
        {
            db.Users.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var dbuser = Get(id);
            db.Users.Remove(dbuser);
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public bool Update(User obj)
        {
            var dbuser = Get(obj.Id);
            db.Entry(dbuser).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
