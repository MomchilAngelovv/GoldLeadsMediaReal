﻿namespace GoldLeadsMedia.CoreApi.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using GoldLeadsMedia.Database;
    using GoldLeadsMedia.Database.Models;
    using GoldLeadsMedia.CoreApi.Services.Common;
    using GoldLeadsMedia.CoreApi.Models.Services.Input;

    public class LeadsService : ILeadsService
    {
        private readonly GoldLeadsMediaDbContext db;

        public LeadsService(
            GoldLeadsMediaDbContext db)
        {
            this.db = db;
        }

        public async Task<Lead> FtdSuccessAsync(Lead lead, DateTime ftdBecomeOn, string status)
        {
            lead.FtdBecameOn = ftdBecomeOn;
            lead.Status = status;

            db.Leads.Update(lead);
            await db.SaveChangesAsync();

            return lead;
        }
        public IEnumerable<Lead> GetLeadsBy(string affiliateId)
        {
            return db.Leads
                .Where(lead => lead.ClickRegistration.AffiliateId == affiliateId)
                .ToList();
        }
        public Lead GetBy(string id, bool searchByBrokerId)
        {
            if (searchByBrokerId)
            {
                return db.Leads
                    .FirstOrDefault(lead => lead.IdInBroker == id);
            }

            return db.Leads
                .FirstOrDefault(lead => lead.Id == id);
        }
        public async Task<Lead> RegisterAsync(LeadsRegisterInputServiceModel serviceModel)
        {
            var lead = new Lead
            {
                FirstName = serviceModel.FirstName,
                LastName = serviceModel.LastName,
                Password = serviceModel.Password,
                Email = serviceModel.Email,
                CountryId = serviceModel.CountryId,
                PhoneNumber = serviceModel.PhoneNumber,
                ClickRegistrationId = serviceModel.ClickRegistrationId,
            };

            var clickRegistration = this.db.ClickRegistrations
                .SingleOrDefault(clickRegistration => clickRegistration.Id == serviceModel.ClickRegistrationId);

            clickRegistration.LeadId = lead.Id;

            db.ClickRegistrations.Update(clickRegistration);
            await db.Leads.AddAsync(lead);
            await db.SaveChangesAsync();

            return lead;
        }
        public async Task<Lead> SendLeadSuccessAsync(Lead lead, string brokerId, string idInBroker)
        {
            lead.UpdatedOn = DateTime.UtcNow;
            lead.BrokerId = brokerId;
            lead.IdInBroker = idInBroker;

            db.Leads.Update(lead);
            await db.SaveChangesAsync();

            return lead;
        }
        public IEnumerable<Lead> GetAll()
        {
            return db.Leads.ToList();
        }
        public Lead GetByEmail(string email)
        {
            return this.db.Leads
                .SingleOrDefault(lead => lead.Email == email);
        }
        public async Task<Lead> SetTestAsync(string leadId)
        {
            var lead = this.db.Leads
                .SingleOrDefault(lead => lead.Id == leadId);

            lead.IsTest = true;
            lead.Information = $"[Mark as test: {DateTime.UtcNow}]";
            this.db.Leads.Update(lead);
            await this.db.SaveChangesAsync();

            return lead;
        }
    }
}
