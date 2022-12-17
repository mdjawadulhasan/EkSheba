using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TaxDTO
    {
        public int Id { get; set; }
        public Nullable<int> IN_FK_NID { get; set; }
        public Nullable<int> TaxAmount { get; set; }
        public Nullable<int> Paid { get; set; }
        public Nullable<int> Balance { get; set; }
        public string Year { get; set; }
    }
}
