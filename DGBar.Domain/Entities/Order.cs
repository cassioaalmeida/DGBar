using DGBar.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Domain.Entities
{
    public class Order:BaseEntity
    {
        public OrderStatus Status { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
    }
}
