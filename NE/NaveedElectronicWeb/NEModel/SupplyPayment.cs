//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NaveedElectronicWeb.NEModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SupplyPayment
    {
        public int Id { get; set; }
        public Nullable<int> SupplyId { get; set; }

        public string UserId { get; set; }
        [Display(Name = "Amount")]
        public int AmountPaid { get; set; }

        [Display(Name ="Payment Date")]
        [DisplayFormat(DataFormatString = "{0:ddd,dd MMM yyyy}")]
        public System.DateTime DatePaid { get; set; }
    
        public virtual Supply Supply { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }

        
    }
}
