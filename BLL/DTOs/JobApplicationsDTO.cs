using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class JobApplicationsDTO
    {
        public int JApid { get; set; }
        public Nullable<int> JAp_FK_NID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string ApplicantName { get; set; }
        public Nullable<int> JAp_FK_JId { get; set; }
    }
}
