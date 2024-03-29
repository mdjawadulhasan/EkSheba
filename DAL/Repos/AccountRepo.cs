﻿using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    class AccountRepo : Repo, IRepo<Account, int>
    {
        public bool Add(Account obj)
        {
            db.Accounts.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var acc = Get(id);
            db.Accounts.Remove(acc);
            return db.SaveChanges() > 0;
        }

        public List<Account> Get()
        {
            return db.Accounts.ToList();
        }

        public Account Get(int id)
        {
            return db.Accounts.Find(id);
        }

        public Account Get(string id)
        {
            throw new NotImplementedException();
        }

        public Account Get(int id, string id2)
        {
            throw new NotImplementedException();
        }

        public Account GetbyFK(int id)
        {
            return db.Accounts.FirstOrDefault(t => t.A_FK_Nid == id);
        }

        public bool Update(Account obj)
        {
            var acc = Get(obj.Id);
            db.Entry(acc).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }


        
    }
}
