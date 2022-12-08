using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class RechargeHistoryDTO
    {
        public int Id { get; set; }
        public int R_FK_Nid { get; set; }
        public int R_FK_RTid { get; set; }
        public int Amount { get; set; }
    }
}
