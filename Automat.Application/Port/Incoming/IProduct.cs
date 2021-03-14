using Automat.Application.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Automat.Application.Port.Incoming
{
    public interface IProduct
    {
        Task<ProductSelectionResult> Selection(ProductSelection productSelection);
        Task<IReadOnlyList<ProductEntity>> ProductGetAll();
        Task<IReadOnlyList<CampaingEntity>> CampaingGetAll();
    }
}
