using Automat.Application.Model;
using Automat.Application.Port.Outgoing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Automat.Test.Adapters
{
    public class FakeCampaingRepository : ICampaingRepository
    {

        public Task<CampaingEntity> AddAsync(CampaingEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(CampaingEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<CampaingEntity>> GetAllAsync()
        {
            CampaingEntity entity = new CampaingEntity();
            entity.Id = 1;
            entity.Slot = 1;
            entity.DiscountRatio = -0.01F;
            entity.CampaignDesc = "deneme";

            List<CampaingEntity> campaingEntities = new List<CampaingEntity>();
            campaingEntities.Add(entity);

            return  campaingEntities.AsReadOnly();
        }

        public Task<IReadOnlyList<CampaingEntity>> GetAsync(Expression<Func<CampaingEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<CampaingEntity>> GetAsync(Expression<Func<CampaingEntity, bool>> predicate = null, Func<IQueryable<CampaingEntity>, IOrderedQueryable<CampaingEntity>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<CampaingEntity>> GetAsync(Expression<Func<CampaingEntity, bool>> predicate = null, Func<IQueryable<CampaingEntity>, IOrderedQueryable<CampaingEntity>> orderBy = null, List<Expression<Func<CampaingEntity, object>>> includes = null, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<CampaingEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CampaingEntity entity)
        {
            throw new NotImplementedException();
        }
    }

}
