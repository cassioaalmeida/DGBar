using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Domain.Entities
{
    class Product :BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public List<Order> Orders { get; set; }
    }
}
