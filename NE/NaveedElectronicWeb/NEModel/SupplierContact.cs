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

    public partial class SupplierContact
    {
        public int Id { get; set; }

        [Required(ErrorMessage  = "Pleae enter  contact title.")]
        [StringLength(14, ErrorMessage = "Please enter valid contact title.")]
        [Display(Name = "Contact Title")]
        public string ContactTitle { get; set; }

        [Required(ErrorMessage  = "Pleae enter  contact number.")]
        [StringLength(24, ErrorMessage = "Please enter valid contact number.")]
        [Display(Name = "Contact Number")]
        public string Number { get; set; }
        public Nullable<int> SupplierId { get; set; }
    
        public virtual Supplier Supplier { get; set; }
    }
}
