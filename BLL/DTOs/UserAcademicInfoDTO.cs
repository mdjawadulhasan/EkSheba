using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserAcademicInfoDTO
    {
        public int RId { get; set; }
        public string PSC { get; set; }
        public string PSC_res { get; set; }
        public string JSC { get; set; }
        public string JSC_res { get; set; }
        public string SSC { get; set; }
        public string SSC_res { get; set; }
        public string HSC { get; set; }
        public string HSC_res { get; set; }
        public Nullable<int> R_FK_NID { get; set; }
    }
}
