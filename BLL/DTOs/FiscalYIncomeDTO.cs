using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class FiscalYIncomeDTO
    {
        public int id { get; set; }
        
        public Nullable<int> Fis_FK_NID { get; set; }
        [Required]
        public Nullable<int> BasicSalary { get; set; }
        [Required]
        public Nullable<int> HouseRent { get; set; }
        [Required] 
        public Nullable<int> MedicalAllowancw { get; set; }
        [Required] 
        public Nullable<int> Conveyance { get; set; }
        [Required] 
        public Nullable<int> Incentive { get; set; }
        [Required]
        public Nullable<int> FestivalBonus { get; set; }
        [Required]
        public string Year { get; set; }

    }
}
