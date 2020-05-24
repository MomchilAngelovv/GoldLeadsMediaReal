﻿namespace GoldLeadsMedia.Database.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using GoldLeadsMedia.Database.Models.Common;

    public class FtdScanError : IEntityMetaData
    {
        public FtdScanError()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }
        
        [Key]
        public string Id { get; set; }
        [Required]
        [MaxLength(400)]
        public string Message { get; set; }
        [Required]
        public string BrokerId { get; set; }

        public virtual Broker Broker { get; set; }

        public DateTime CreatedOn { get; set ; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string Information { get; set; }
    }
}
