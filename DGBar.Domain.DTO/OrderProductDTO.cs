using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Domain.DTO
{
    public class OrderProductDTO
    {
        public int OrderID { get; set; }
        public OrderDTO Order { get; set; }
        public int ProductID { get; set; }
        public ProductDTO Product { get; set; }
        public int Quantity { get; set; }
    }
}
