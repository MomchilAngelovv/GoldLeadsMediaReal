﻿namespace GoldLeadsMedia.Database.Models
{
    using System;

    using GoldLeadsMedia.Database.Models.Common;

    public class LeadError : IEntityMetaData
    {
        public LeadError()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        public string Id { get; set; }
        public string Message { get; set; }
        public string Information { get; set; }

        public string LeadId { get; set; }
        public string PartnerId { get; set; }

        public virtual Lead Lead{ get; set; }
        public virtual Partner Partner { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set ; }
        public DateTime? DeletedOn { get; set; }
    }
}
