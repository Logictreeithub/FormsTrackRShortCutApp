//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FormsTrackR1
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblUserModule
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public string DisplayName { get; set; }
        public int OrderDetailId { get; set; }
        public System.DateTime ExpiryDate { get; set; }
        public bool IsVisible { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public string ModuleJson { get; set; }
        public Nullable<int> DisplayOrderType { get; set; }
    }
}
