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
    
    public partial class TblEmailTemplate
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public System.DateTime ModifiedOn { get; set; }
    }
}
