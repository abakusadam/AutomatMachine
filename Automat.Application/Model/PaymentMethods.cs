using Automat.Application.Port.Outgoing.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automat.Application.Model
{
    public class PaymentMethod : Entity
    {
        //public int PaymentMethodId { get; set; }
        public string PaymentMethodDesc { get; set; }
    }
}
