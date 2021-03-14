using Automat.Application.Port.Outgoing.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automat.Application.Model
{
    public class PaymentByCashEntity :  Entity
    {
        public int TransactionId { get; set; }
        public decimal CashAmount { get; set; }

        public PaymentByCashEntity()
        {
            TransactionId = 0;
            CashAmount = 0;
        }
    }
}
