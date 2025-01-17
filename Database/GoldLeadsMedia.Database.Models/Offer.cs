﻿namespace GoldLeadsMedia.Database.Models
{
    using System;
    using System.Collections.Generic;

    using GoldLeadsMedia.Database.Models.Common;

    public class Offer : IEntityMetaData
    {
        public Offer()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Number { get; set; }
        public string ActionFlow { get; set; }
        public decimal? PayPerAction { get; set; }
        public decimal? PayPerLead { get; set; }
        public decimal? PayPerClick { get; set; }

        public int PayTypeId { get; set; }
        public int CountryTierId { get; set; }
        public int AccessId { get; set; }
        public int VerticalId { get; set; } 
        public int LanguageId { get; set; }
        public int TargetDeviceId { get; set; }

        public virtual PayType PayType { get; set; }
        public virtual CountryTier CountryTier { get; set; }
        public virtual Access Access { get; set; }
        public virtual Vertical Vertical { get; set; }
        public virtual Language Language { get; set; }
        public virtual TargetDevice TargetDevice { get; set; }

        public virtual ICollection<OfferLandingPage> OffersLandingPages { get; set; }
        public virtual ICollection<OfferOfferGroup> OffersGroups { get; set; }
        public virtual ICollection<ApiRegistration> ApiRegistrations { get; set; }
        public virtual ICollection<ClickRegistration> ClickRegistrations { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string Information { get; set; }
    }
}
