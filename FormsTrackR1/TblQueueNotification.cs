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
    
    public partial class TblQueueNotification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AccountId { get; set; }
        public bool IsActive { get; set; }
        public string Type { get; set; }
        public string QueueObjectName { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public int IsCompleted { get; set; }
        public bool IsNotificationShown { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public Nullable<int> RandomNumber { get; set; }
    }
}
