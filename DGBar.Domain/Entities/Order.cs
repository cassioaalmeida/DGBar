using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Domain.Entities
{
    class Order:BaseEntity
    {
        public List<Product> Products { get; set; }
    }
}
