//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class FiscalYIncome
    {
        public int id { get; set; }
        public Nullable<int> Fis_FK_NID { get; set; }
        public Nullable<int> BasicSalary { get; set; }
        public Nullable<int> HouseRent { get; set; }
        public Nullable<int> MedicalAllowancw { get; set; }
        public Nullable<int> Conveyance { get; set; }
        public Nullable<int> Incentive { get; set; }
        public Nullable<int> FestivalBonus { get; set; }
        public string Year { get; set; }
    
        public virtual UsersDetail UsersDetail { get; set; }
    }
}
