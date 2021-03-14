using Automat.Application.Model;
using Automat.Application.Port.Outgoing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automat.Infrastructure.Adapter
{

    public class CampaingRepository : Repository<CampaingEntity>, ICampaingRepository
    {

        public CampaingRepository(AutomatDbContext dbContext) : base(dbContext)
        {
        }

    }
}
