using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class JobCirculerDTO
    {
        public int JCid { get; set; }
        public string Title { get; set; }
        public Nullable<int> Grade { get; set; }
        public string QualificationLevel { get; set; }
        public string Minresult { get; set; }
        public string Department { get; set; }
        public Nullable<int> Agereq { get; set; }
    }
}
