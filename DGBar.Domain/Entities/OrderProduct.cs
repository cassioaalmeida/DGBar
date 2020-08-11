using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Domain.Entities
{
    public class OrderProduct
    {
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
