﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GoldLeadsMedia.CoreApi.Models.ServiceModels
{
    public class OffersAssignLandingPagesInputServiceModel
    {
        public string OfferId { get; set; }
        public IEnumerable<string> LandingPageIds { get; set; }
    }
}