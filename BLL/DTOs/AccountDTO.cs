using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public Nullable<int> A_FK_Nid { get; set; }
        public Nullable<int> Balance { get; set; }
        public Nullable<int> Status { get; set; }
    }
}
