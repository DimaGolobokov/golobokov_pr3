//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace golobokov_pr3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MedicalClaims
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MedicalClaims()
        {
            this.InspectorReports = new HashSet<InspectorReports>();
            this.PaymentInvoices = new HashSet<PaymentInvoices>();
        }
    
        public int ClaimID { get; set; }
        public Nullable<int> ContractID { get; set; }
        public System.DateTime ClaimDate { get; set; }
        public string MedicalService { get; set; }
        public string ClaimStatus { get; set; }
        public string Comments { get; set; }
    
        public virtual Contracts Contracts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InspectorReports> InspectorReports { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentInvoices> PaymentInvoices { get; set; }
    }
}
