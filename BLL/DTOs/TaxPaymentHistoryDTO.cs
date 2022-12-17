using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TaxPaymentHistoryDTO
    {
        public int Id { get; set; }
        public Nullable<int> IH_FK_TxID { get; set; }
        public Nullable<int> IH_FK_NID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> Amount { get; set; }
    }
}
