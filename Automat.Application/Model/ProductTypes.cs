using Automat.Application.Port.Outgoing.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automat.Application.Model
{
    public class ProductTypes : Entity
    {
        public string ProdyctTypeName { get; set; }

        public ProductTypes()
        {
            ProdyctTypeName = string.Empty;
        }
    }
}
