using Automat.Application.Port.Outgoing.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automat.Application.Model
{
    public class CampaingEntity: Entity
    {
        public int Slot { get; set; }
        public string CampaignDesc { get; set; }
        public decimal DiscountRatio { get; set; }
        public CampaingEntity()
        {
            Slot = 0;
            CampaignDesc = string.Empty;
            DiscountRatio = 0;
        }
    }
}
