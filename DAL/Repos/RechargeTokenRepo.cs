using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    class RechargeTokenRepo : Repo, IRepo<RechargeToken, int>
    {
        public bool Add(RechargeToken obj)
        {
            db.RechargeTokens.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var tk = Get(id);
            db.RechargeTokens.Remove(tk);
            return db.SaveChanges() > 0;
        }

        public List<RechargeToken> Get()
        {
            throw new NotImplementedException();
        }

        public RechargeToken Get(int id)
        {
            return db.RechargeTokens.Find(id);
        }

        public RechargeToken Get(string id)
        {
            return db.RechargeTokens.FirstOrDefault(t => t.Token.Equals(id));
        }

        public RechargeToken Get(int id, string id2)
        {
            throw new NotImplementedException();
        }

        public RechargeToken GetbyFK(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(RechargeToken obj)
        {
            var acc = Get(obj.Id);
            db.Entry(acc).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
