﻿namespace GoldLeadsMedia.Database
{
    using System.Reflection;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    using GoldLeadsMedia.Database.Models;

    //TODO: ASK FOR OFFER GROUPS AND ACCESSES
    public class GoldLeadsMediaDbContext : IdentityDbContext<GoldLeadsMediaUser, GoldLeadsMediaRole, string>
    {
        public GoldLeadsMediaDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Access> Accesses { get; set; }
        public DbSet<ApiRegistration> ApiRegistrations { get; set; }
        public DbSet<Broker> Brokers { get; set; }
        public DbSet<ClickRegistration> ClickRegistrations { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryTier> CountryTiers { get; set; }
        public DbSet<DeveloperError> DeveloperErrors { get; set; }
        public DbSet<FtdScanError> FtdScanErrors { get; set; }
        public DbSet<FtdScanResult> FtdScanResults { get; set; }
        public DbSet<LandingPage> LandingPages { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<OfferGroup> OfferGroups { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<OfferLandingPage> OffersLandingPages { get; set; }
        public DbSet<OfferOfferGroup> OffersOfferGroups { get; set; }
        public DbSet<PayType> PayTypes { get; set; }
        public DbSet<SendLeadError> SendLeadErrors { get; set; }
        public DbSet<TargetDevice> TargetDevices { get; set; }
        public DbSet<TrackerConfiguration> TrackerConfigurations { get; set; }
        public DbSet<Vertical> Verticals { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
