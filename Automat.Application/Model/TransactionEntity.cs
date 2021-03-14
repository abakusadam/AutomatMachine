using Automat.Application.Port.Outgoing.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automat.Application.Model
{
    public class TransactionEntity:Entity
    {
        public int Slot { get; set; }
        public int SelectedPieces { get; set; }
        public decimal TransactionAmount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime CreateDate { get; set; }

        public TransactionEntity()
        {
            Slot = 0;
            SelectedPieces = 0;
            TransactionAmount = 0;
            IsPaid = false;
            CreateDate = DateTime.Now;
        }
    }
}
