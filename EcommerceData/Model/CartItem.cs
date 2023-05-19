using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceData.Model
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
