using Automat.Application.Port.Incoming;
using Automat.Application.Port.Outgoing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automat.Application
{
    public interface IAutomatFacade: IProduct, IPayment
    {
    }
}
