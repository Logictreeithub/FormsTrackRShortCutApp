﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FormsTrackRProdEntities : DbContext
    {
        public FormsTrackRProdEntities()
            : base("name=FormsTrackRProdEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__EFMigrationsHistory> C__EFMigrationsHistory { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<TblAccountDetail> TblAccountDetails { get; set; }
        public virtual DbSet<TblApplicationTimeZone> TblApplicationTimeZones { get; set; }
        public virtual DbSet<TblAppName> TblAppNames { get; set; }
        public virtual DbSet<TblAzureNHPushRegistration> TblAzureNHPushRegistrations { get; set; }
        public virtual DbSet<TblBlockedSender> TblBlockedSenders { get; set; }
        public virtual DbSet<TblButtonRespons> TblButtonResponses { get; set; }
        public virtual DbSet<TblCardsBillingInfo> TblCardsBillingInfoes { get; set; }
        public virtual DbSet<TblCategory> TblCategories { get; set; }
        public virtual DbSet<TblContactGroup> TblContactGroups { get; set; }
        public virtual DbSet<TblContact> TblContacts { get; set; }
        public virtual DbSet<TblDiscount> TblDiscounts { get; set; }
        public virtual DbSet<TblEmailTemplate> TblEmailTemplates { get; set; }
        public virtual DbSet<TblFormResponseReport> TblFormResponseReports { get; set; }
        public virtual DbSet<TblFormRespons> TblFormResponses { get; set; }
        public virtual DbSet<TblForm> TblForms { get; set; }
        public virtual DbSet<TblFormTransaction> TblFormTransactions { get; set; }
        public virtual DbSet<TblHelpData> TblHelpDatas { get; set; }
        public virtual DbSet<TblLabelTemplate> TblLabelTemplates { get; set; }
        public virtual DbSet<TblLoginTracking> TblLoginTrackings { get; set; }
        public virtual DbSet<TblNoticeHistory> TblNoticeHistories { get; set; }
        public virtual DbSet<TblNotification> TblNotifications { get; set; }
        public virtual DbSet<TblOrderDetail> TblOrderDetails { get; set; }
        public virtual DbSet<TblPermission> TblPermissions { get; set; }
        public virtual DbSet<TblPrintQRCode> TblPrintQRCodes { get; set; }
        public virtual DbSet<TblQRCodeButtonReport> TblQRCodeButtonReports { get; set; }
        public virtual DbSet<TblQRCode> TblQRCodes { get; set; }
        public virtual DbSet<TblQRFormsMapping> TblQRFormsMappings { get; set; }
        public virtual DbSet<TblQueueNotification> TblQueueNotifications { get; set; }
        public virtual DbSet<TblReplyMessageHistory> TblReplyMessageHistories { get; set; }
        public virtual DbSet<TblSMSSentHistory> TblSMSSentHistories { get; set; }
        public virtual DbSet<TblSubscription> TblSubscriptions { get; set; }
        public virtual DbSet<TblUserCustomSetting> TblUserCustomSettings { get; set; }
        public virtual DbSet<TblUserModule> TblUserModules { get; set; }
        public virtual DbSet<TblUserRole> TblUserRoles { get; set; }
        public virtual DbSet<TblUsersDeviceInfo> TblUsersDeviceInfoes { get; set; }
        public virtual DbSet<TblCustomerDeskNote> TblCustomerDeskNotes { get; set; }
        public virtual DbSet<TblMasterPermission> TblMasterPermissions { get; set; }
    }
}
