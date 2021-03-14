using Automat.Application.Model;
using Automat.Application.Port.Outgoing;
using Automat.Application.Port.Outgoing.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Automat.Infrastructure.Adapter
{
    public class ProductRepository : Repository<ProductEntity>, IProductRepository
    {
        //private AutomatDbContext _dbContext;

        public ProductRepository(AutomatDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ProductEntity> UpdateProduct(ProductEntity product)
        {
            try
            {
                _dbContext.Products.AddRange(product);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                return product;
            }

            return product;
        }
    }
}
