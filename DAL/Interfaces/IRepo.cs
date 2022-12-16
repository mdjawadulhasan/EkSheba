using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<CLASS, ID>
    {
        List<CLASS> Get();
        CLASS Get(ID id);

        CLASS GetbyFK(ID id);
        CLASS Get(string id);

        CLASS Get(int id, string id2);
        bool Add(CLASS obj);
        bool Update(CLASS obj);
        bool Delete(ID id);
    }
}
