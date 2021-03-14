using Automat.Application.Port.Outgoing.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automat.Application.Model
{
    public class PaymentByCreditCardEntity : Entity
    {
        public int TransactionId { get; set; }
        public string Pan { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string Cvc { get; set; }

        public PaymentByCreditCardEntity()
        {
            TransactionId = 0;
            Pan = string.Empty;
            Month = 0;
            Year = 0;
            Cvc = string.Empty;
        }
    }
}
