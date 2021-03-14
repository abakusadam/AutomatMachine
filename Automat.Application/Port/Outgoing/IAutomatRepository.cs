using Automat.Application.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Automat.Application.Port.Outgoing
{
    public interface IAutomatRepository
    {
        //Task<IList<ProductEntity>> GetProducts();
        //Task<IList<PaymentMethod>> GetPaymentMethods();
        //Task<IList<Campaing>> GetCampaings();
        //Task<Campaing> GetCampaing(int slot);
        Task<ProductEntity> UpdateProduct(ProductEntity product);
    }
}
