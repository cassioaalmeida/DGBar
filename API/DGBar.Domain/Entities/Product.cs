using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DGBar.Domain.Entities
{
    public class Product :BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        [JsonIgnore]
        public List<OrderProduct> OrderProducts { get; set; }
    }
}
