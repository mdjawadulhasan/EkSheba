using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PassportAppDTO
    {
        public int Id { get; set; }
        public Nullable<int> PA_FK_NID { get; set; }

        
        public Nullable<System.DateTime> ApplyDate { get; set; }
        public Nullable<System.DateTime> DelDate { get; set; }
        [Required]
        public Nullable<int> Type { get; set; }
    }
}
