using System;
using System.Collections.Generic;
using System.Text;

namespace Automat.Application.Model
{
    public class ProductSelectionResult
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public int Slot { get; set; }
        public int TransactionId { get; set; }
        public decimal TotalAmount { get; set; }

        public ProductSelectionResult()
        {
            TransactionId = 0;
            Slot = 0;
            TotalAmount = 0;
            Message = string.Empty;
        }
    }
}
