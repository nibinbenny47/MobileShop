//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MobileShop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Product()
        {
            this.tbl_Booking = new HashSet<tbl_Booking>();
        }
    
        public int product_Id { get; set; }
        public string product_Name { get; set; }
        public string product_Price { get; set; }
        public Nullable<int> company_Id { get; set; }
        public string product_Description { get; set; }
        public string product_Image { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Booking> tbl_Booking { get; set; }
        public virtual tbl_Company tbl_Company { get; set; }
        public virtual tbl_Product tbl_Product1 { get; set; }
        public virtual tbl_Product tbl_Product2 { get; set; }
    }
}
