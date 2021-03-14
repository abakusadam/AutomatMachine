using System;
using System.Collections.Generic;
using System.Text;

namespace Automat.Application.Model
{
    public class ProductSelection
    {
        public int Slot { get; set; }
        public int SelectedPieces { get; set; }
        public int SugarLevel { get; set; }

        public ProductSelection()
        {
            Slot = 0;
            SelectedPieces = 0;
            SugarLevel = 0;
        }
    }
}
