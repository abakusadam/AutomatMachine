using Automat.Application.Port.Outgoing.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automat.Application.Model
{
    public class ProductEntity : Entity
    {
        public int Slot { get; set; }
        public int ProductTypeId { get; set; }
        public string ProductName { get; set; }
        public int NumberOfProducts { get; set; }
        public decimal PriceOfProduct { get; set; }
        public bool IsRequiredSugarSelection { get; set; }
        public bool IsAvailable { get; set; }


        public ProductEntity()
        {
            Slot = 0;
            ProductTypeId = 0;
            ProductName = string.Empty;
            NumberOfProducts = 0;
            PriceOfProduct = 0;
            IsRequiredSugarSelection =false;
            IsAvailable = false;
        }


    }
}
