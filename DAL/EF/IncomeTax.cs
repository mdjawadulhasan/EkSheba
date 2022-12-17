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
    
    public partial class IncomeTax
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IncomeTax()
        {
            this.TaxPaymentHistories = new HashSet<TaxPaymentHistory>();
        }
    
        public int Id { get; set; }
        public Nullable<int> IN_FK_NID { get; set; }
        public Nullable<int> TaxAmount { get; set; }
        public Nullable<int> Paid { get; set; }
        public Nullable<int> Balance { get; set; }
        public string Year { get; set; }
    
        public virtual UsersDetail UsersDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaxPaymentHistory> TaxPaymentHistories { get; set; }
    }
}
