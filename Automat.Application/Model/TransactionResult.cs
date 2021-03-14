using System;
using System.Collections.Generic;
using System.Text;

namespace Automat.Application.Model
{
    public class TransactionResult
    {
        public int Slot { get; set; }
        public int TransactionId { get; set; }
        public string ProdcutName { get; set; }
        public int NumberOfProductsReceived { get; set; }
        public string PaymentMethod { get; set; }
        public decimal ReversedAmount { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public TransactionResult()
        {
            Slot = 0;
            TransactionId = 0;
            ProdcutName = string.Empty;
            NumberOfProductsReceived = 0;
            PaymentMethod = string.Empty;
            ReversedAmount = 0;
            Message = string.Empty;
        }
    }
}
