﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class InsuranceMedicalCompanyDBEntities : DbContext
    {
        public InsuranceMedicalCompanyDBEntities()
            : base("name=InsuranceMedicalCompanyDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Auth> Auth { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<HealthcareInstitutions> HealthcareInstitutions { get; set; }
        public virtual DbSet<InspectorReports> InspectorReports { get; set; }
        public virtual DbSet<MedicalClaims> MedicalClaims { get; set; }
        public virtual DbSet<PaymentInvoices> PaymentInvoices { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}