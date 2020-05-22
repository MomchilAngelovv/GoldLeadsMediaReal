﻿namespace GoldLeadsMedia.Database.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using GoldLeadsMedia.Database.Models.Common;

    public class Broker : IEntityMetaData
    {
        public Broker()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        [Key]
        public string Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string Information { get; set; }
    }
}
