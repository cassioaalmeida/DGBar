using DGBar.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DGBar.Domain.Entities
{
    public class Order:BaseEntity
    {
        public OrderStatus Status { get; set; }
        [JsonIgnore]
        public List<OrderProduct> OrderProducts { get; set; }
    }
}
