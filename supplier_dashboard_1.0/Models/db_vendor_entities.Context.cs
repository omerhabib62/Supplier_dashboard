﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace supplier_dashboard_1._0.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db_vendor : DbContext
    {
        public db_vendor()
            : base("name=db_vendor")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<customers_requisation> customers_requisation { get; set; }
        public virtual DbSet<db_User> db_User { get; set; }
        public virtual DbSet<DC_invoice> DC_invoice { get; set; }
        public virtual DbSet<DC_items> DC_items { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<general_sales_Invoice> general_sales_Invoice { get; set; }
        public virtual DbSet<general_sales_items> general_sales_items { get; set; }
        public virtual DbSet<item> items { get; set; }
        public virtual DbSet<item_brand> item_brand { get; set; }
        public virtual DbSet<item_category> item_category { get; set; }
        public virtual DbSet<PO> POes { get; set; }
        public virtual DbSet<PO_items> PO_items { get; set; }
        public virtual DbSet<quotation> quotations { get; set; }
        public virtual DbSet<quotation_items> quotation_items { get; set; }
        public virtual DbSet<requisation_items> requisation_items { get; set; }
        public virtual DbSet<ST_invoice> ST_invoice { get; set; }
        public virtual DbSet<ST_items> ST_items { get; set; }
        public virtual DbSet<supplier_items> supplier_items { get; set; }
        public virtual DbSet<system_order> system_order { get; set; }
        public virtual DbSet<user_desc> user_desc { get; set; }
    }
}
