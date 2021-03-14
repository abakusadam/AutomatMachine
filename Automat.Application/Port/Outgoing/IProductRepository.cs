using Automat.Application.Model;
using Automat.Application.Port.Outgoing.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Automat.Application.Port.Outgoing
{
    public interface IProductRepository : IRepository<ProductEntity>
    {
        //Task<IList<ProductEntity>> GetProducts();
        Task<ProductEntity> UpdateProduct(ProductEntity product);
    }

}
