using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PassportDTO
    {
        public int Id { get; set; }
        public int P_FK_NID { get; set; }
        public Nullable<System.DateTime> IssueDate { get; set; }
        public Nullable<System.DateTime> ValidTill { get; set; }
        public Nullable<int> Status { get; set; }
    }
}
